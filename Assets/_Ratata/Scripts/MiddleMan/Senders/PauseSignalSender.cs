using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSignalSender : MonoBehaviour
{
    [SerializeField] private PauseSignalSO _pauseSignalSO;

    public void SendPauseSignal()
    {
        _pauseSignalSO.PauseGame();
    }

    public void SendResumeSignal()
    {
        _pauseSignalSO.ResumeGame();
    }
}
