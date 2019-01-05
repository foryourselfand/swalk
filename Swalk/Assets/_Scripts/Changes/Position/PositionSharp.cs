using UnityEngine;

public class PositionSharp : PositionChanger
{
    public override void Change(float t)
    {
        _transformLink.position = Vector3.MoveTowards(_transformLink.position, _targetVector, t);
    }
}