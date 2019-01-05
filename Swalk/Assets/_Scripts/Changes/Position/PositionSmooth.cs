using UnityEngine;

public class PositionSmooth : PositionChanger
{
    protected override void Change(float t)
    {
        _transformLink.position = Vector3.Lerp(_transformLink.position, _targetVector, t);
    }
}