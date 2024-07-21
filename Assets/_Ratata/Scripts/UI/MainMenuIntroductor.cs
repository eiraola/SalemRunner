using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuIntroductor : MonoBehaviour
{
    [SerializeField] private Transform _initPoint;
    [SerializeField] private CanvasGroup _buttonsCanvasGroup;
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private UnityEvent _onEnterAnimationFinish;
    private Vector3 _originalScale;
    private Vector3 _endPoint;
    private CancellationTokenSource _cancellationTokenSource;

    private void Awake()
    {
        _endPoint = transform.position;
        _originalScale = transform.localScale;
    }

    private void OnEnable()
    {
        SetNewCancellationToken();
        _cancellationTokenSource = new CancellationTokenSource();
        transform.position = _initPoint.position;
        _buttonsCanvasGroup.alpha = 0.0f;
        PlayIntro(_cancellationTokenSource.Token).Forget();
    }

    private async UniTaskVoid PlayIntro(CancellationToken cancelToken)
    {
        EnableButtons(false);

        await transform.DOMove(_endPoint, 1.0f).SetUpdate(UpdateType.Normal, true).WithCancellation(cancelToken);
        await transform.DOScale(_originalScale * 0.8f, 0.25f).SetUpdate(UpdateType.Normal, true).WithCancellation(cancelToken);
        await transform.DOScale(_originalScale, 0.25f).SetUpdate(UpdateType.Normal, true).SetEase(Ease.OutBounce).WithCancellation(cancelToken);
        await _buttonsCanvasGroup.DOFade(1.0f, 0.1f).SetUpdate(UpdateType.Normal, true).WithCancellation(cancelToken);
        _onEnterAnimationFinish?.Invoke();

        EnableButtons(true);


    }

    public void CloseMenu() 
    {
        SetNewCancellationToken();
        PlayExitAnim(_cancellationTokenSource.Token).Forget();
    }

    private async UniTaskVoid PlayExitAnim(CancellationToken cancelToken)
    {
        EnableButtons(false);
        await _buttonsCanvasGroup.DOFade(0.0f, 0.4f).SetUpdate(UpdateType.Normal, true).WithCancellation(cancelToken);
        await transform.DOScale(Vector3.zero, 0.4f).SetUpdate(UpdateType.Normal, true).WithCancellation(cancelToken);
    }

    private void EnableButtons(bool enabled)
    {
        foreach (Button button in _buttons)
        {
            button.enabled = enabled;
        }
    }

    private void SetNewCancellationToken()
    {
        if (_cancellationTokenSource != null)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        _cancellationTokenSource = new CancellationTokenSource();
    }
}
