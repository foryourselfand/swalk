using UnityEngine;

public class Clicker : MonoBehaviour
{
    private CanvasGroup canvasGroupLink;
    private _Clickable clickableLink;

    private void Awake()
    {
        canvasGroupLink = GetComponent<CanvasGroup>();
        clickableLink = GetComponent<_Clickable>();
    }

    public void ActionOnClick()
    {
        if (canvasGroupLink.alpha >= 0.9)
            clickableLink.ActionOnClick();
    }
}