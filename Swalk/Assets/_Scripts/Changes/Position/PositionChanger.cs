using System;
using UnityEngine;

public abstract class PositionChanger : Changer
{
    protected Transform _transformLink;

    protected Vector3 _targetVector;

    private void Awake()
    {
        _transformLink = gameObject.transform;
    }

    protected override bool CheckWithTolerance(float tolerance)
    {
        return Vector3.SqrMagnitude(_transformLink.position - _targetVector) > tolerance;
    }

    protected abstract override void Change(float time);

    protected override void ActionOnEnd()
    {
        Debug.Log("PositionChanger ActionOnEnd");
        _transformLink.position = _targetVector;
    }

    public void TestMoving()
    {
        changing = true;
        _targetVector = _transformLink.position;
        _transformLink.position += new Vector3(0, 100, 0);
    }
}