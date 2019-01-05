using System.Collections;
using UnityEngine;

public abstract class Changer : MonoBehaviour
{
    public float speed;

    [HideInInspector] public bool isDone;

    public abstract bool CheckTargetRich();

    public abstract void Change(float t);

    public IEnumerator ChangeOverSpeed()
    {
        isDone = false;
        while (!CheckTargetRich())
        {
            Change(speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        endSetUp();
        isDone = true;
    }

    public virtual void endSetUp()
    {
    }
}