using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuAnimator : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons = new List<Button> ();
    private Vector3 _originalPose;
    private Vector3 _originalScale;


    private void Awake()
    {
        _originalPose = transform.position;
        _originalScale = transform.localScale;
    }

    private void OnEnable()
    {
        EnterMenuAnimation();
    }

    public void EnterMenuAnimation(Action onEndFunction = null)
    {
        EnableButtons(false);
        transform.position = transform.position - Vector3.up * 10;
        transform.localScale = Vector3.zero;
        Sequence sequence = DOTween.Sequence();
        sequence.Insert(0, transform.DOMove(_originalPose, 1.0f));
        sequence.Insert(0, transform.DOScale(_originalScale, 1.0f)).SetEase(Ease.OutBounce);
        sequence.OnComplete(() => {
            PlayAction(onEndFunction);
            EnableButtons(true);
        }
       );
    }

    public void ExitMenuAnimation(Action onEndFunction = null)
    {
        EnableButtons(false);
        transform.position = _originalPose;
        transform.localScale = _originalScale;
        Sequence sequence = DOTween.Sequence();
        sequence.Insert(0, transform.DOMove(transform.position - Vector3.up * 10, 0.5f));
        sequence.Insert(0, transform.DOScale(Vector3.zero, 0.5f)).SetEase(Ease.InBounce);
        sequence.OnComplete(() => PlayAction(onEndFunction));
    }

    private void PlayAction(Action onEndFunction = null)
    {
        onEndFunction?.Invoke();
    }

    private void EnableButtons(bool enable)
    {
        foreach (Button button in _buttons)
        {
            button.enabled = enable;
        }
    }
}
