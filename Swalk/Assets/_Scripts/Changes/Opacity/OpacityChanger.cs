using System.Collections;
using UnityEngine;

public class OpacityChanger : Changer
{
    private CanvasGroup canvasGroupLink;

    private void Awake()
    {
        canvasGroupLink = gameObject.GetComponent<CanvasGroup>();
    }

    public override void Change()
    {
        canvasGroupLink.alpha = Mathf.Lerp(
            canvasGroupLink.alpha,
            targetAlpha,
            speed * Time.deltaTime
        );
    }

    public void TestFunc()
    {
        StartCoroutine(ChangeOverSeconds(0, 0.5f));
    }

    public IEnumerator ChangeOverSeconds(float end, float seconds)
    {
        float elapsedTime = 0;
        float startingAlpha = canvasGroupLink.alpha;
        while (elapsedTime < seconds)
        {
            canvasGroupLink.alpha = Mathf.Lerp(startingAlpha, end, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        canvasGroupLink.alpha = end;
    }
}