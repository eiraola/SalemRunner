using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private SoundSignalSO _soundSignalSO;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<SoundClip> _audios = new List<SoundClip>();
    private Dictionary<EClip, AudioClip> _audioSourceDic = new Dictionary<EClip, AudioClip>();

    private void Start()
    {
        //The only reason to work this way is because Unity inspector doesnt show dictionarys. 
        // The correct way to use a dictionary this way should be creating a custom inspector view.
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
        _soundSignalSO.onClipSound.AddListener(PlayClip);
    }

    private void OnDisable()
    {
        _soundSignalSO.onClipSound.RemoveListener(PlayClip);
    }

    private void PlayClip(EClip clip)
    {
        _audioSource.PlayOneShot(_audioSourceDic[clip]);
    }

}
