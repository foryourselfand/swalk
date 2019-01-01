using UnityEngine;

public class PositionSmooth : PositionOnce
{
    public override void Change()
    {
        transform.position = Vector3.Lerp(transform.position, targetVector, speed * Time.deltaTime);
    }
}