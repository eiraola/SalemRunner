using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{
    [SerializeField] private UnityEvent _onDamageReceived = new UnityEvent();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(Constants.TAG_DAMAGER))
        {
            return;
        }
        _onDamageReceived?.Invoke();
    }
}
