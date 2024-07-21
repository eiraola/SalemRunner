using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField] private SoundSignalSO _musicSoundSignal;
    
    public void PlayMainMenuMusic()
    {
        _musicSoundSignal.PlayClipSound(EClip.MainMenu);
    }

    public void PlayMainGameMusic()
    {
        _musicSoundSignal.PlayClipSound(EClip.MainGame);
    }

    public void StopMusic()
    {
        _musicSoundSignal.StopClip();
    }
}
