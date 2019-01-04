using System.Collections;
using UnityEngine;

public abstract class Changer : MonoBehaviour
{
    public bool isDone;

    public abstract void Change(float time);

//    public IEnumerator ChangeOverSpeed(Vector3 endVector, float speed)
//    {
//        while (transform.position != endVector)
//        {
//            transform.position = Vector3.MoveTowards(transform.position, endVector, speed * Time.deltaTime);
//            yield return new WaitForEndOfFrame();
//        }
//    }

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

        endSetUp();
        isDone = true;
    }

    public virtual void endSetUp()
    {
    }
}