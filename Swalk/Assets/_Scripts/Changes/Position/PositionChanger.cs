using UnityEngine;

public abstract class PositionChanger : Changer
{
    [SerializeField] private float multiplier;

    [SerializeField] private ChangeType changeType;

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

    private static float _lerpTime;

    private static bool _fromSlowToFast;

    private static Vector2 _velocity = Vector2.one;

    #endregion

    #region DELEGATES(Change Actions)

    private delegate Vector2 ChangeAction(Vector2 current, Vector2 target, float speed, float t);

    private ChangeAction _changeAction;

    private static Vector2 SpecialSmoothAction(Vector2 current, Vector2 target, float speed, float t)
    {
        if (_fromSlowToFast)
            _lerpTime += t / speed;
        else
            _lerpTime = t * speed;

        return Vector2.Lerp(current, target, _lerpTime);
    }

    private static Vector2 DefaultSmoothAction(Vector2 current, Vector2 target, float speed, float t)
    {
        return Vector2.SmoothDamp(current, target, ref _velocity, speed * t * 10f);
    }

    private static Vector2 SharpAction(Vector2 current, Vector2 target, float speed, float t)
    {
        return Vector2.MoveTowards(current, target, speed * t * 5);
    }

    private enum ChangeType
    {
        SpecialSmooth,
        DefaultSmooth,
        Sharp
    }

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

        switch (changeType)
        {
            case ChangeType.SpecialSmooth:
                _changeAction = SpecialSmoothAction;
                break;
            case ChangeType.DefaultSmooth:
                _changeAction = DefaultSmoothAction;
                break;
            case ChangeType.Sharp:
                _changeAction = SharpAction;
                break;
        }
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
        PositionLink = _changeAction(PositionLink, _target, Speed, t);
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