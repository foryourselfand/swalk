using UnityEngine;

public abstract class Changer : MonoBehaviour
{
    public float speed;

    protected bool changing;

    private void Update()
    {
        if (!changing) return;

        if (CheckWithTolerance())
        {
            Change(speed * Time.deltaTime);
            ChangeSpeed();
        }
        else
        {
            changing = false;
            ActionOnEnd();
        }
    }

    protected abstract bool CheckWithTolerance();

    protected abstract void Change(float time);

    protected abstract void ActionOnEnd();

    protected virtual void ChangeSpeed()
    {
    }
}