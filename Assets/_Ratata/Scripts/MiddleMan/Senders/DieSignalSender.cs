using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DieSignalSender : MonoBehaviour
{
    [SerializeField] private DieSignalSO _dieSignal;

    public void SendDieMessage()
    {
        _dieSignal.onDieEvent?.Invoke();
    }
}
