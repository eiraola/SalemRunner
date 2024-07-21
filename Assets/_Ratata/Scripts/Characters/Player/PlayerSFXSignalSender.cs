using UnityEngine;

public class PlayerSFXSignalSender : MonoBehaviour
{
    [SerializeField] private SoundSignalSO _soundSignalSO;
    public void PlayDieSound()
    {
        _soundSignalSO.PlayClipSound(EClip.Die);
    }
}
