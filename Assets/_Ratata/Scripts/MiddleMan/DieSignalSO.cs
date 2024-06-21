using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "DieSignalSO", menuName = "ScriptableObjects/DeadManagement", order = 2)]
[System.Serializable]
public class DieSignalSO : ScriptableObject
{
    public UnityEvent onDieEvent = new UnityEvent();

    public void SendDieSignal()
    {
        onDieEvent?.Invoke();
    }
}
