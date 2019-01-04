using System.Collections;
using UnityEngine;

public abstract class PositionChanger : Changer
{
    protected Vector3 vectorLink;

    protected Vector3 startingVector;
    protected Vector3 endingVector;

    private void Awake()
    {
        vectorLink = gameObject.transform.position;
    }

    public void ChangeAlphaOverSeconds(float seconds, Vector3 endValue)
    {
        startingVector = vectorLink;
        endingVector = endValue;
        StartCoroutine(ChangeOverSeconds(seconds));
    }

    public override void endSetUp()
    {
        vectorLink = endingVector;
    }
}