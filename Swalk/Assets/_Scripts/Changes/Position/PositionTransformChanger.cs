using UnityEngine;

public class PositionTransformChanger : PositionChanger
{
    private Transform _transformLink;

    private void Awake()
    {
        _transformLink = GetComponent<Transform>();
    }

    protected override void setLink(Vector2 value)
    {
        _transformLink.localPosition = new Vector3(value.x, _transformLink.position.y, value.y);
    }
}