using System.Collections;
using UnityEngine;

public class OpacityChanger : Changer
{
    private CanvasGroup canvasGroupLink;
    private IEnumerator temp;

    private void Awake()
    {
        canvasGroupLink = gameObject.GetComponent<CanvasGroup>();
    }

    public void TestFunc()
    {
        StartMagic(ChangeOverSeconds(0, 5));
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