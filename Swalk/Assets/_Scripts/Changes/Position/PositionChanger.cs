using UnityEngine;

public abstract class PositionChanger : Changer
{
    protected Vector2 _targetVector;

    protected Vector2 _positionLink;

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

    public void SetVectorTarget(Vector2 targetVector, bool needToMove)
    {
        changing = true;
        lastX = targetVector.x;
        lastY = targetVector.y;
        _targetVector = PositionLink + targetVector;
        if (!needToMove) return;
        _targetVector -= targetVector;
        PositionLink += targetVector;
    }

    public void SetVectorTarget(Vector2 targetVector)
    {
        SetVectorTarget(targetVector, false);
    }

    public void SetClockwiseTarget()
    {
        Debug.Log("Fuck");
        SetVectorTarget(new Vector2(lastX, lastY));
    }

    protected abstract void setLink(Vector2 value);

    protected override bool CheckWithTolerance()
    {
        return Vector2.SqrMagnitude(PositionLink - _targetVector) > Vector2.kEpsilon;
    }

    protected override void Change(float t)
    {
        PositionLink = Vector2.Lerp(PositionLink, _targetVector, t);
    }

    protected override void ActionOnEnd()
    {
        Debug.Log("PositionChanger ActionOnEnd");
        PositionLink = _targetVector;
    }
}