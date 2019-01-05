using UnityEngine;

public class PositionSmooth : PositionChanger
{
    public override void Change(float time)
    {
        transformLink.position = Vector3.Lerp(transformLink.position, targetVector, time);
    }
}