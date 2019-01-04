using UnityEngine;

public class PositionSmooth : PositionChange
{
    public override void Change(Vector3 startingPosition, Vector3 endingPosition, float speedValue)
    {
        transform.position = Vector3.Lerp(startingPosition, endingPosition, speedValue);
    }
}