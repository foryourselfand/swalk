using UnityEngine;

public class PositionTransformChanger : PositionChanger
{
    private Transform _transformLink;

    private void Awake()
    {
        _transformLink = GetComponent<Transform>();
    }

    protected override void DefineScale()
    {
//        Debug.Log(string.Format("{2} {0} {1}", _transformLink.localScale.x.ToString(),
//            _transformLink.localScale.z.ToString(), name));
    }

    protected override void setLink(Vector2 value)
    {
        _transformLink.position = new Vector3(value.x, _transformLink.position.y, value.y);
    }
}
