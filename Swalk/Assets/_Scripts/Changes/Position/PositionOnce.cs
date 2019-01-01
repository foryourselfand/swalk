using UnityEngine;

public abstract class PositionOnce : Changer
{
    protected float width, height;

    private float multiply = 2.5f;

    private void Start()
    {
        width = transform.localScale.x;
        height = transform.localScale.y;
    }

    public void MoveBy(float onX, float onY)
    {
        targetVector = transform.position;
        transform.position = new Vector3(width * onX * multiply, height * onY * multiply);
    }

    public void MoveBy(float byY)
    {
        targetVector = transform.position;
        transform.position = new Vector3(0, byY);
    }

    public abstract override void Change();
}