using System.Collections;
using UnityEngine;

public class OpacityChanger : Changer
{
    private CanvasGroup canvasGroupLink;

    private float startingAlpha;
    private float endingAlpha;

    private void Awake()
    {
        canvasGroupLink = gameObject.GetComponent<CanvasGroup>();
    }

    public void ChangeAlphaOverSeconds(float seconds, float endValue)
    {
        startingAlpha = canvasGroupLink.alpha;
        endingAlpha = endValue;
        StartCoroutine(ChangeOverSeconds(seconds));
        canvasGroupLink.alpha = endingAlpha;
        Debug.Log("I'm here");
    }

    public override void Change(float time)
    {
        canvasGroupLink.alpha = Mathf.Lerp(startingAlpha, endingAlpha, time);
    }
}