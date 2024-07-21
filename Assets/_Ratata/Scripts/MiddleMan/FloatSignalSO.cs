using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "FloatChangedSignal", menuName = "ScriptableObjects/ReactiveValues/Float", order = 2)]
[System.Serializable]
public class FloatSignalSO : ScriptableObject
{
    public UnityEvent<float> onValueChanged = new UnityEvent<float>();

    public void ChangeValue(float newValue)
    {
        onValueChanged?.Invoke(newValue);
    }
}
