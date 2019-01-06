using UnityEngine;

public class PositionRectChanger : PositionChanger
{
    private void Awake()
    {
        _transformLink = GetComponent<Transform>();
    }

    protected override void setLink(Vector3 value)
    {
        _transformLink.position = new Vector3(value.x, value.y, _transformLink.position.z);
    }
}