using UnityEngine;

public class PositionRectChanger : PositionChanger
{
    private RectTransform _rectLink;

    protected override void DefineTransform()
    {
        _rectLink = GetComponent<RectTransform>();
    }

    protected override void DefineScale(ref float width, ref float height)
    {
        width = _rectLink.rect.width;
        height = _rectLink.rect.height;

        #if DEBUG_PRINT
        Debug.Log(string.Format("{0}\tW:{1} H:{2}", name, Width.ToString(), Height.ToString()));
        #endif
    }

    protected override void DefineStartPosition(ref Vector2 startPosition)
    {
        startPosition = _rectLink.anchoredPosition;

        #if DEBUG_PRINT
        Debug.Log(string.Format("N:{0}\tSP:{1}", name, startPosition.ToString()));
        #endif
    }

    protected override void SetTransformLink(Vector2 value)
    {
        _rectLink.anchoredPosition = new Vector2(value.x, value.y);
    }
}