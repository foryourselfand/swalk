using UnityEngine;

public class PositionSharp : PositionChanger
{
    public override void Change(float time)
    {
        transformLink.position = Vector3.MoveTowards(transformLink.position, targetVector, time);
    }
}