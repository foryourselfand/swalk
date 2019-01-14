using UnityEngine;

public class PositionTransformChanger : PositionChanger
{
    private Transform _transformLink;

    protected override void DefineTransform()
    {
        _transformLink = GetComponent<Transform>();
    }

    protected override void DefineScale()
    {
        Width = _transformLink.localScale.x;
        Height = _transformLink.localScale.z;

        #if DEBUG_PRINT
        Debug.Log(string.Format("{0}\tW:{1} H:{2}", name, Width.ToString(), Height.ToString()));
        #endif
    }

    protected override void SetTransformLink(Vector2 value)
    {
        _transformLink.localPosition = new Vector3(value.x, _transformLink.localPosition.y, value.y);
    }
}