using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private FloatSignalSO _scenarioMovementSignal;
    [SerializeField] private float _movementSpeed;
    private float scenarioMovementValue = 0;

    void Update()
    {
        Move(Time.deltaTime);
    }

    private void OnEnable()
    {
        _scenarioMovementSignal.onValueChanged.AddListener(AddScenarioMovement);
    }

    private void OnDisable()
    {
        _scenarioMovementSignal.onValueChanged.RemoveListener(AddScenarioMovement);
        scenarioMovementValue = 0;

    }

    private void AddScenarioMovement(float scenarioMovement)
    {
        scenarioMovementValue += scenarioMovement;
    }

    public void Move(float deltaTime)
    {
        transform.position += (-transform.right * _movementSpeed * Time.deltaTime) - Vector3.right * scenarioMovementValue;
        scenarioMovementValue = 0;
    }



}
