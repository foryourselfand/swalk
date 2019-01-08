using UnityEngine;

public class PositionRectChanger : PositionChanger
{
    private RectTransform _rectLink;

    private void Awake()
    {
        _rectLink = GetComponent<RectTransform>();
    }

    protected override void setLink(Vector2 value)
    {
        _rectLink.anchoredPosition = new Vector2(value.x * 50, value.y * 50);
    }

//    protected override Vector2 getLink()
//    {
//        return _rectLink.pivot;
//    }
}