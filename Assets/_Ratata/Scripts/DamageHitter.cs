using UnityEngine;
using UnityEngine.Events;

public class DamageHitter : MonoBehaviour
{
    [HideInInspector] public UnityEvent onPlayerHit = new UnityEvent();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.TAG_PLAYER))
        {
            onPlayerHit?.Invoke();
        }
    }
}
