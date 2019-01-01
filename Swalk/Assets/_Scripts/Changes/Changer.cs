using UnityEngine;

public abstract class Changer : MonoBehaviour, _IChangable
{
    public float speed;

    protected Vector3 targetVector;
    protected float targetAlpha;

    public abstract void Change();
}