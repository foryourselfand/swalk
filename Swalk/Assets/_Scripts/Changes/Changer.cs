using UnityEngine;

public abstract class Changer : MonoBehaviour
{
    public float speed;

    private const float Tolerance = Vector2.kEpsilon;

    protected bool changing;

    private void Update()
    {
        if (!changing) return;

        if (CheckWithTolerance(Tolerance))
        {
            Change(speed * Time.deltaTime);
        }
        else
        {
            changing = false;
            ActionOnEnd();
        }
    }

    protected abstract bool CheckWithTolerance(float tolerance);

    protected abstract void Change(float time);

    protected abstract void ActionOnEnd();
}