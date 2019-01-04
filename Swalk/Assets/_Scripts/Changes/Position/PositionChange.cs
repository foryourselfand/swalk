using System.Collections;
using UnityEngine;

public abstract class PositionChange : MonoBehaviour
{
    protected Transform transformLink;

    private void Awake()
    {
        transformLink = gameObject.transform;
    }

    public IEnumerator ChangeOverSeconds(Vector3 endingPosition, float seconds)
    {
        float elapsedTime = 0;
        var startingPosition = transformLink.position;
        while (elapsedTime < seconds)
        {
            Change(startingPosition, endingPosition, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transformLink.position = endingPosition;
    }

    public abstract void Change(Vector3 startingPosition, Vector3 endingPosition, float speedValue);
}