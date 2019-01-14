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

    #region CHANGER

    protected override bool CheckWithTolerance()
    {
        return Math.Abs(_canvasGroupLink.alpha - _targetAlpha) > 0.01f;
    }

    protected override void Change(float time)
    {
        _canvasGroupLink.alpha = Mathf.MoveTowards(_canvasGroupLink.alpha, _targetAlpha, time);
    }

    protected override void ActionOnEnd()
    {
        _canvasGroupLink.alpha = _targetAlpha;
//        if (_targetAlpha == 0)
//            gameObject.SetActive(false);


        #if DEBUG_PRINT
        Debug.Log(string.Format("Opacity\t{0}\tEND", name));
        #endif
    }

    #endregion

    public void SetOpacityTarget(float targetOpacity)
    {
        Changing = true;
        _targetAlpha = targetOpacity;

        #if DEBUG_PRINT
        Debug.Log(string.Format("Opacity\t{0}\tSTART", name));
        #endif
    }
}