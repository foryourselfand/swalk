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

    public override void Change(float time)
    {
        canvasGroupLink.alpha = Mathf.Lerp(startingAlpha, endingAlpha, time);
    }

    public void ChangeAlphaOverSeconds(float seconds, float endValue)
    {
        startingAlpha = canvasGroupLink.alpha;
        endingAlpha = endValue;
        StartCoroutine(ChangeOverSeconds(seconds));
    }

    public override void endSetUp()
    {
        canvasGroupLink.alpha = endingAlpha;
    }
}