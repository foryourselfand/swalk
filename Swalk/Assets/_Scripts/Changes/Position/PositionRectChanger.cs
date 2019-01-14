using UnityEngine;

public class PositionRectChanger : PositionChanger
{
    private RectTransform _rectLink;

    protected override void DefineTransform()
    {
        _rectLink = GetComponent<RectTransform>();
    }

    protected override void DefineScale()
    {
        Width = _rectLink.rect.width;
        Height = _rectLink.rect.height;

        #if DEBUG_PRINT
        Debug.Log(string.Format("{0}\tW:{1} H:{2}", name, Width.ToString(), Height.ToString()));
        #endif
    }

    protected override void SetTransformLink(Vector2 value)
    {
        _rectLink.anchoredPosition = new Vector2(value.x, value.y);
    }
}