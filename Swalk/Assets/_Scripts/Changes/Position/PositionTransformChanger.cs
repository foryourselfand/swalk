using UnityEngine;

public class PositionTransformChanger : PositionChanger
{
    private Transform _transformLink;

    private void Awake()
    {
        _transformLink = gameObject.transform;
    }

    protected override void setLink(Vector2 value)
    {
        Debug.Log("setLink");
        _transformLink.position = new Vector3(value.x, value.y, 50);
    }
}