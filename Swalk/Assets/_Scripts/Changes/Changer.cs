using UnityEngine;

public abstract class Changer : MonoBehaviour
{
    public float speed;

    protected Vector3 targetVector;
    protected float targetAlpha;

    public abstract void Change();
}