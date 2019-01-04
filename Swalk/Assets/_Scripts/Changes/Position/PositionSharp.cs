using UnityEngine;

public class PositionSharp : PositionChange
{
    public override void Change(Vector3 startingPosition, Vector3 endingPosition, float speedValue)
    {
        transformLink.position = Vector3.MoveTowards(startingPosition, endingPosition, speedValue);
    }
}