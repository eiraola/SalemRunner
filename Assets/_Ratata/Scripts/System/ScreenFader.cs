using UnityEngine;
using DG.Tweening;
using System;
public class ScreenFader : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeTime = 1.0f;
    private Action _onFadeCompleteAction = null;
    public bool _isFading = false;

    public void SetBlackScreen()
    {
        _canvasGroup.alpha = 1.0f;
    }

    public void FadeIn(Action endFunction = null) {
        if (_isFading)
        {
            return;
        }
        _onFadeCompleteAction = endFunction;
        DoFade(1.0f, 0.0f);
    }

    public void FadeOut(Action endFunction = null)
    {
        if (_isFading)
        {
            return;
        }
        _onFadeCompleteAction = endFunction;
        DoFade(0.0f, 1.0f);
    }

    private void DoFade(float initValue, float endValue)
    {
       
        _isFading = true;
        _canvasGroup.alpha = initValue;
        Sequence sequence = DOTween.Sequence();
        sequence.Insert(0, _canvasGroup.DOFade(endValue, _fadeTime).SetUpdate(UpdateType.Normal, true));
        sequence.onComplete = OnFadeComplete;
    }

    private void OnFadeComplete()
    {
        _isFading = false;
        _onFadeCompleteAction?.Invoke();
        _onFadeCompleteAction = null;
    }
}
