using UnityEngine;

public abstract class PositionChanger : Changer
{
    [SerializeField] private float multiplier;

    #region VAR_VECTORS(CHANGER)

    private Vector2 _startPosition;
    private Vector2 _positionLink;

    public Vector2 PositionLink
    {
        private get { return _positionLink; }
        set
        {
            _positionLink = value;
            SetTransformLink(_positionLink);
        }
    }

    private Vector2 _target;

    #endregion

    #region VAR_SMOOTH_MOVEMENT

    private float _lerpTime;

    private bool _fromSlowToFast;

    #endregion

    #region VAR_OTHER

    protected float Width, Height;
    private float _lastX, _lastY;

    #endregion

    #region DEFINING(AWAKE&START)

    private void Awake()
    {
        DefineTransform();
        DefineScale();
    }

    private void Start()
    {
        _startPosition = _positionLink;
    }

    protected abstract void DefineTransform();
    protected abstract void DefineScale();

    #endregion

    #region CHANGER

    protected abstract void SetTransformLink(Vector2 value);

    protected override bool CheckWithTolerance()
    {
        return Vector2.SqrMagnitude(PositionLink - _target) > Vector2.kEpsilon;
    }

    protected override void Change(float t)
    {
        //PositionLink = Vector2.SmoothDamp(PositionLink, _targetVector, ref velocity, 0.1f * speed); //private Vector2 velocity = Vector2.zero;//

        if (_fromSlowToFast)
            _lerpTime += Time.deltaTime / speed;
        else
            _lerpTime = Time.deltaTime * speed;

        PositionLink = Vector2.Lerp(PositionLink, _target, _lerpTime);
    }

    protected override void ActionOnEnd()
    {
        PositionLink = _target;
        _fromSlowToFast = !_fromSlowToFast;
        _lerpTime = 0;


        #if DEBUG_PRINT
        Debug.Log(string.Format("Position\t{0}\tEND", name));
        #endif
    }

    #endregion

    private Vector2 GetMultiplyTarget(Vector2 originalTarget)
    {
        return new Vector2(originalTarget.x * Width * multiplier, originalTarget.y * Height * multiplier);
    }

    public void SetTarget(Vector2 target)
    {
        Changing = true;
        _lastX = target.x;
        _lastY = target.y;

        #if DEBUG_PRINT
        Debug.Log(string.Format("Position\t{0}\tSTART", name));
        #endif
    }

    public void SetTargetFromStart(Vector2 target)
    {
        SetTarget(target);
        _target = _startPosition;
        PositionLink = _startPosition + GetMultiplyTarget(target);
    }

    public void SetTargetFromCurrent(Vector2 target)
    {
        SetTarget(target);
        _target = PositionLink + GetMultiplyTarget(target);
    }

    public void SetPreviousTarget()
    {
        SetTargetFromCurrent(new Vector2(_lastX, _lastY));
    }

    public void SetContinuingTarget()
    {
        SetTargetFromCurrent(new Vector2(-_lastX, -_lastY));
    }
}