using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDistance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textUI;
    private float _distance;

    public void SetText(float doneDistance)
    {
        _distance += doneDistance;
        _textUI.text = $"Distance: {Mathf.Floor(_distance).ToString()}";
    }
}
