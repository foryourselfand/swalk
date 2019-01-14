using UnityEngine;

public abstract class PositionChanger : Changer
{
    protected Vector2 _targetVector;

    protected Vector2 _positionLink;

    private Vector2 _startPosition;

    public Vector2 PositionLink
    {
        private get { return _positionLink; }
        set
        {
            _positionLink = value;
            setLink(_positionLink);
        }
    }

    private float lastX, lastY;

    private float lerpTime;

    private bool fromSlowToFast;

    private void Start()
    {
        _startPosition = _positionLink;
    }

    public void SetTarget(Vector2 target)
    {
        changing = true;
        lastX = target.x;
        lastY = target.y;
    }

    public void SetTargetFromStart(Vector2 target)
    {
        SetTarget(target);
        _targetVector = _startPosition;
        PositionLink = _startPosition + target;
    }

    public void SetTargetFromCurrent(Vector2 target)
    {
        SetTarget(target);
        _targetVector = PositionLink + target;
    }

    public void SetPreviousTarget()
    {
        SetTargetFromCurrent(new Vector2(lastX, lastY));
    }

    public void SetContinuingTarget()
    {
        SetTargetFromCurrent(new Vector2(-lastX, -lastY));
    }

    protected abstract void setLink(Vector2 value);

    protected override void ActionOnEnd()
    {
        Debug.Log(string.Format("///{0} position///", name));
        PositionLink = _targetVector;
        fromSlowToFast = !fromSlowToFast;
        lerpTime = 0;
    }


    protected override bool CheckWithTolerance()
    {
        return Vector2.SqrMagnitude(PositionLink - _targetVector) > Vector2.kEpsilon;
    }

    protected override void Change(float t)
    {
        //PositionLink = Vector2.SmoothDamp(PositionLink, _targetVector, ref velocity, 0.1f * speed); //private Vector2 velocity = Vector2.zero;//

        if (fromSlowToFast)
            lerpTime += Time.deltaTime / speed;
        else
            lerpTime = Time.deltaTime * speed;

        PositionLink = Vector2.Lerp(PositionLink, _targetVector, lerpTime);
    }
}
