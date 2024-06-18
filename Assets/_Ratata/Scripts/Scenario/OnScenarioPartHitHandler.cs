using UnityEngine;
using UnityEngine.Events;

public class OnScenarioPartHitHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _onPlayerHit = new UnityEvent();
    void Start()
    {
        SetDamagerListeners();
    }

    private void SetDamagerListeners()
    {
        DamageHitter[] hitters = GetComponentsInChildren<DamageHitter>();

        for (int i = 0; i < hitters.Length; i++)
        {
            hitters[i].onPlayerHit.AddListener(OnPlayerHit);
        }
    }

    private void OnPlayerHit()
    {
        _onPlayerHit?.Invoke();
        Debug.LogError("Ouch!");
    }

}
