using System;
using UnityEngine;

public class OpacityChanger : MonoBehaviour
{
    public float speed;

    private CanvasGroup canvasGroupLink;

    private float startAlpha;
    private float targetAlpha;

    private void Awake()
    {
        canvasGroupLink = gameObject.GetComponent<CanvasGroup>();
    }

    public void SetTarget(float endAlpha)
    {
        startAlpha = canvasGroupLink.alpha;
        targetAlpha = endAlpha;
    }

    private void Update()
    {
        if (Math.Abs(canvasGroupLink.alpha - targetAlpha) > 0.1)
        {
            canvasGroupLink.alpha = Mathf.Lerp(canvasGroupLink.alpha, targetAlpha, speed * Time.deltaTime);
        }
        else
        {
            canvasGroupLink.alpha = targetAlpha;
            if (targetAlpha == 0)
                gameObject.SetActive(false);
        }
    }
}