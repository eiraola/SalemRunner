using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "PauseSignalSO", menuName = "ScriptableObjects/PauseManagement", order = 2)]
[System.Serializable]
public class PauseSignalSO : ScriptableObject
{
    public UnityEvent onGamePause = new UnityEvent();
    public UnityEvent onGameResume = new UnityEvent();

    public void PauseGame()
    {
        onGamePause?.Invoke();
    }

    public void ResumeGame()
    {
        onGameResume?.Invoke();
    }

    private void OnEnable()
    {
        onGamePause.RemoveAllListeners();
        onGameResume.RemoveAllListeners();
    }

}