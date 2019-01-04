using UnityEngine;

public class PositionSmooth : PositionChanger
{
    public override void Change(float time)
    {
        vectorLink = Vector3.Lerp(startingVector, endingVector, time);
    }
}