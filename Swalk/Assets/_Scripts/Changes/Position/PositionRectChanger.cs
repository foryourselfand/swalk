using UnityEngine;

public class PositionRectChanger : PositionChanger
{
    private Transform _transformLink;

    private void Awake()
    {
        _transformLink = GetComponent<Transform>();
    }

    protected override void setLink(Vector2 value)
    {
        _transformLink.position = new Vector2(value.x, value.y);
    }
}