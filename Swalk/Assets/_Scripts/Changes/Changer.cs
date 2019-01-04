using System.Collections;
using UnityEngine;

public abstract class Changer : MonoBehaviour
{
    public bool isDone;

    public abstract void Change(float time);

    public IEnumerator ChangeOverSeconds(float seconds)
    {
        isDone = false;

        float elapsedTime = 0;
        while (elapsedTime < seconds)
        {
            Change(elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        isDone = true;
    }
}