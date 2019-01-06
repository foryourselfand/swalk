using UnityEngine;

public abstract class PositionChanger : Changer
{
    protected Vector2 _targetVector;

    protected Vector2 _vectorLink;

    public Vector2 VectorLink
    {
        get { return _vectorLink; }
        set
        {
            _vectorLink = value;
            setLink(_vectorLink);
        }
    }

    protected abstract void setLink(Vector2 value);

    protected override bool CheckWithTolerance(float tolerance)
    {
        return Vector2.SqrMagnitude(VectorLink - _targetVector) > tolerance;
    }

    protected override void Change(float t)
    {
        VectorLink = Vector2.Lerp(VectorLink, _targetVector, t);
    }

    protected override void ActionOnEnd()
    {
        Debug.Log("PositionChanger ActionOnEnd");
        VectorLink = _targetVector;
    }

    public void TestMoving()
    {
        changing = true;
        _targetVector = VectorLink;
        VectorLink += new Vector2(10, 100);
    }
}