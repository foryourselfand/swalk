using UnityEngine;

public class PositionSmooth : PositionChanger
{
    public override void Change(float t)
    {
        _transformLink.position = Vector3.Lerp(_transformLink.position, _targetVector, t);
    }
}