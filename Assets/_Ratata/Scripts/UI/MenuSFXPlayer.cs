using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFXPlayer : MonoBehaviour
{
    [SerializeField] private SoundSignalSO _soundSignalSO;

    public void PlayButtonSound()
    {
        _soundSignalSO.PlayClipSound(EClip.ButtonPress);
    }

    public void PlayMainMenuEnterSound()
    {
        _soundSignalSO.PlayClipSound(EClip.MainMenuEnter);
    }
}
