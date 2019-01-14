using UnityEngine;

public class PositionRectChanger : PositionChanger
{
    private RectTransform _rectLink;

    private void Awake()
    {
        _rectLink = GetComponent<RectTransform>();
    }

    protected override void DefineScale()
    {
//        Debug.Log(string.Format("{2} {0} {1}", _rectLink.rect.width.ToString(),
//            _rectLink.rect.height.ToString(), name));
    }

    protected override void setLink(Vector2 value)
    {
        _rectLink.anchoredPosition = new Vector2(value.x * 50, value.y * 50);
    }
}
