using UnityEngine;

public abstract class PositionChanger : Changer
{
    protected Vector2 _targetVector;

    protected Vector2 _positionLink;

    public Vector2 PositionLink
    {
        get
        {
//            _positionLink = getLink();
            return _positionLink;
        }
        set
        {
            _positionLink = value;
            setLink(_positionLink);
        }
    }

    protected abstract void setLink(Vector2 value);

//    protected abstract Vector2 getLink();

    protected override bool CheckWithTolerance(float tolerance)
    {
        return Vector2.SqrMagnitude(PositionLink - _targetVector) > tolerance;
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
    
    
    public void TestRect()
    {
        changing = true;
        _targetVector = PositionLink;
        PositionLink += new Vector2(1, 0);  
    }

    public void TestTrans()
    {
        changing = true;
        _targetVector = PositionLink;
        PositionLink += new Vector2(1, 0); 
    }
}