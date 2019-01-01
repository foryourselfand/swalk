using UnityEngine;

public class PositionSharp : PositionOnce
{
    public override void Change()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetVector, speed * Time.deltaTime);
    }
}