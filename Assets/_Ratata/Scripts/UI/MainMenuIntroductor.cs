using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuIntroductor : MonoBehaviour
{
    [SerializeField] private Transform _initPoint;

    [SerializeField] private List<Button> _buttons;
    private Vector3 _originalScale;
    private Vector3 _endPoint;

    private void Awake()
    {
        _endPoint = transform.position;
        _originalScale = transform.localScale;
    }

    private void OnEnable()
    {
        transform.position = _initPoint.position;
        //transform.localScale = transform.localScale * 0.8f;
        PlayIntro();
    }

    private void PlayIntro()
    {
        EnableButtons(false);
        Sequence sequence = DOTween.Sequence();
        sequence.Insert(0, transform.DOMove(_endPoint, 0.5f).SetUpdate(UpdateType.Normal, true));
        sequence.OnComplete(() => {
            OnPostitionReached();
        });
    }

    private void OnPostitionReached()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Insert(0, transform.DOScale(_originalScale * 0.8f, 0.25f).SetUpdate(UpdateType.Normal, true))
            .Insert(0.25f, transform.DOScale(_originalScale, 0.25f).SetUpdate(UpdateType.Normal, true))
            .SetEase(Ease.OutBounce);
        sequence.OnComplete(() => { EnableButtons(true); });
    }

    public void CloseMenu() {

        Sequence sequence = DOTween.Sequence();
        sequence.Insert(0, transform.DOScale(Vector3.zero, 0.5f).SetUpdate(UpdateType.Normal, true))
            .SetEase(Ease.InBounce);
    }

    private void EnableButtons(bool enabled)
    {
        foreach (Button button in _buttons)
        {
            button.enabled = enabled;
        }
    }
}
