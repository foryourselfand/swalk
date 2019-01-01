using UnityEngine;

public class OpacityChanger : Changer
{
    public override void Change()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(
            gameObject.GetComponent<CanvasGroup>().alpha,
            targetAlpha,
            speed * Time.deltaTime
        );
    }
}