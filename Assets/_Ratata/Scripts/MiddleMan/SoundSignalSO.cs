using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewSFXSignal", menuName = "ScriptableObjects/System/Sound", order = 2)]

[System.Serializable]
public class SoundSignalSO : ScriptableObject
{
    public UnityEvent<EClip> onClipSound = new UnityEvent<EClip> ();
    public UnityEvent onClipStop = new UnityEvent();

    public void PlayClipSound(EClip clip)
    {
        onClipSound?.Invoke(clip);
    }

    public void StopClip()
    {
        onClipStop?.Invoke();
    }
}
