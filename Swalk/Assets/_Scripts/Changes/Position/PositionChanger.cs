using UnityEngine;

public abstract class PositionChanger : Changer
{
    [SerializeField] private float multiplier;

    #region VAR_VECTORS(CHANGER)

    private Vector2 _target;
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

    #endregion

    #region VAR_SMOOTH_MOVEMENT

    private float _lerpTime;

    private bool _fromSlowToFast;

    #endregion

    #region VAR_OTHER

    private float _width, _height;
    private float _lastX, _lastY;

    #endregion

    #region DEFINING

    private void Awake()
    {
        DefineTransform();
        DefineScale(ref _width, ref _height);
        DefineStartPosition(ref _startPosition);
    }

    protected abstract void DefineTransform();
    protected abstract void DefineScale(ref float width, ref float height);
    protected abstract void DefineStartPosition(ref Vector2 startPosition);

    #endregion

    #region CHANGER

    protected abstract void SetTransformLink(Vector2 value);

    protected override bool CheckWithTolerance()
    {
        return Vector2.SqrMagnitude(PositionLink - _target) > Vector2.kEpsilon;
    }

    protected override void Change(float t)
    {
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

    #region FUNCTIONALITY

    private Vector2 GetMultiplyTarget(Vector2 originalTarget)
    {
        return new Vector2(originalTarget.x * _width * multiplier, originalTarget.y * _height * multiplier);
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

    #endregion
}