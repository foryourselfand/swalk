using UnityEngine;

public abstract class PositionChanger : Changer
{
    protected Vector3 _targetVector;

    protected Transform _transformLink;

    public Transform TransformLink
    {
        get { return _transformLink; }
        set
        {
            _transformLink = value;
            setLink(_transformLink.position);
        }
    }

    protected abstract void setLink(Vector3 value);

    protected override bool CheckWithTolerance(float tolerance)
    {
        return Vector3.SqrMagnitude(TransformLink.position - _targetVector) > tolerance;
    }

    protected override void Change(float t)
    {
        TransformLink.position = Vector3.Lerp(TransformLink.position, _targetVector, t);
    }

    protected override void ActionOnEnd()
    {
        Debug.Log("PositionChanger ActionOnEnd");
        TransformLink.position = _targetVector;
    }
    
    
    public void TestRect()
    {
        changing = true;
        _targetVector = TransformLink.position;
        TransformLink.position += new Vector3(0, 100);  
    }

    public void TestTrans()
    {
        changing = true;
        _targetVector = TransformLink.position;
        TransformLink.position += Vector3.right; 
    }
}