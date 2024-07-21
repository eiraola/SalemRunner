using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private SoundSignalSO _soundSignalSO;
    [SerializeField] private float _fadeTime = 0.5f;
    [SerializeField] private float _maxVolume = 0.5f;
    [SerializeField] private List<SoundClip> _audios = new List<SoundClip>();
    private Dictionary<EClip, AudioClip> _audioSourceDic = new Dictionary<EClip, AudioClip>();
    private CancellationTokenSource _cancellationTokenSource;

    private void Start()
    {
        foreach (SoundClip clip in _audios)
        {
            if (!_audioSourceDic.ContainsKey(clip.clipType))
            {
                _audioSourceDic.Add(clip.clipType, clip.clip);
            }
        }
    }

    private void OnEnable()
    {
        _soundSignalSO.onClipSound.AddListener(StartPlayingMusic);
        _soundSignalSO.onClipStop.AddListener(StopPlayingCurrentClip);
    }

    private void OnDisable()
    {
        _soundSignalSO.onClipSound.RemoveListener(StartPlayingMusic);
        _soundSignalSO.onClipStop.RemoveListener(StopPlayingCurrentClip);
    }

    private void StartPlayingMusic(EClip clip)
    {
        CreateNewCancelationToken();
        _musicSource.volume = 0.0f;
        _musicSource.clip = _audioSourceDic[clip];
        _musicSource.Play();
        ChangeMusicVolumeAsync(_maxVolume, _cancellationTokenSource.Token).Forget();
    }

    private void StopPlayingCurrentClip()
    {
        CreateNewCancelationToken();
        ChangeMusicVolumeAsync(0.0f, _cancellationTokenSource.Token).Forget();
    }

    private async UniTaskVoid ChangeMusicVolumeAsync(float endvalue, CancellationToken token)
    {
        await _musicSource.DOFade(endvalue, _fadeTime).WithCancellation(token);
    }

    private void CreateNewCancelationToken()
    {
        if (_cancellationTokenSource != null )
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        _cancellationTokenSource = new CancellationTokenSource();
    }
}
