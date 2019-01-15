using UnityEngine;

public class PositionTransformChanger : PositionChanger
{
    private Transform _transformLink;

    protected override void DefineTransform()
    {
        _transformLink = GetComponent<Transform>();
    }

    protected override void DefineScale(ref float width, ref float height)
    {
        width = _transformLink.localScale.x;
        height = _transformLink.localScale.z;

        #if DEBUG_PRINT
        Debug.Log(string.Format("N:{0}\tW:{1} H:{2}", name, Width.ToString(), Height.ToString()));
        #endif
    }

    protected override void DefineStartPosition(ref Vector2 startPosition)
    {
        startPosition = new Vector2(_transformLink.localPosition.x, _transformLink.localPosition.z);

        #if DEBUG_PRINT
        Debug.Log(string.Format("N:{0}\tSP:{1}", name, startPosition.ToString()));
        #endif
    }

    protected override void SetTransformLink(Vector2 value)
    {
        _transformLink.localPosition = new Vector3(value.x, _transformLink.localPosition.y, value.y);
    }
}