using System;
using UnityEngine;

public class OpacityChanger : MonoBehaviour
{
    public float speed;

    private CanvasGroup _canvasGroupLink;

    private float _targetAlpha;

    private void Awake()
    {
        _canvasGroupLink = gameObject.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _canvasGroupLink.alpha = 0;
        _targetAlpha = 1;
    }

    public void SetTarget(float targetAlpha)
    {
        _targetAlpha = targetAlpha;
    }

    private void Update()
    {
        if (Math.Abs(_canvasGroupLink.alpha - _targetAlpha) > 0.01)
        {
            _canvasGroupLink.alpha = Mathf.Lerp(_canvasGroupLink.alpha, _targetAlpha, speed * Time.deltaTime);
        }
        else
        {
            _canvasGroupLink.alpha = _targetAlpha;
            if (_targetAlpha == 0)
                gameObject.SetActive(false);
        }
    }
}