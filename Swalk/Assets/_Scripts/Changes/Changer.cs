using UnityEngine;

public abstract class Changer : MonoBehaviour
{
    [SerializeField] [Range(1, 10)] protected float Speed;

    protected bool Changing;

    private void Update()
    {
        if (!Changing) return;

        if (CheckWithTolerance())
        {
            Change(Time.deltaTime);
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