using UnityEngine;

public enum EClip
{
    ButtonPress,
    Land,
    Jump,
    Impact,
    Die,
    Win,
    WinPoint,
    Ghost,
    MainMenu,
    MainGame,
    MainMenuEnter,
    PauseMenuEnter,
    PauseMenuExit,
}

[System.Serializable]
public class SoundClip 
{
    public AudioClip clip;
    public EClip clipType;
}
