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

    public void SetVectorTarget(Vector2 targetVector)
    {
        changing = true;
        _targetVector = PositionLink;
        PositionLink += targetVector;
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