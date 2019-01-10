using System;
using UnityEngine;

public class OpacityChanger : Changer
{
    private CanvasGroup _canvasGroupLink;

    private float _targetAlpha;

    private void Awake()
    {
        _canvasGroupLink = gameObject.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _canvasGroupLink.alpha = 0;
    }

    public void SetOpacityTarget(float targetOpacity)
    {
        changing = true;
        _targetAlpha = targetOpacity;
    }

    protected override bool CheckWithTolerance()
    {
        return Math.Abs(_canvasGroupLink.alpha - _targetAlpha) > 0.01f;
    }

    protected override void Change(float time)
    {
        _canvasGroupLink.alpha = Mathf.Lerp(_canvasGroupLink.alpha, _targetAlpha, time);
    }

    protected override void ActionOnEnd()
    {
        Debug.Log("OpacityChanger ActionOnEnd");
        _canvasGroupLink.alpha = _targetAlpha;
        if (_targetAlpha == 0)
            gameObject.SetActive(false);
    }
}