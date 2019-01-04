using UnityEngine;

public class PositionSharp : PositionChanger
{
    public override void Change(float time)
    {
        vectorLink = Vector3.MoveTowards(startingVector, endingVector, time);
    }
}