using UnityEngine;

public abstract class Changer : MonoBehaviour
{
    [SerializeField] protected float speed;

    protected bool Changing;

    private void Update()
    {
        if (!Changing) return;

        if (CheckWithTolerance())
        {
            Change(speed * Time.deltaTime);
        }
        else
        {
            Changing = false;
            ActionOnEnd();
        }
    }

    protected abstract bool CheckWithTolerance();

    protected abstract void Change(float time);

    protected abstract void ActionOnEnd();
}