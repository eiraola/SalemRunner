using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    [SerializeField] private float frequency = 1.0f;
    [SerializeField] private float apperture = 1.0f;
    [SerializeField] private Transform _axis;
    private float currentTime = 0;

    private void OnEnable()
    {
        currentTime = 0;
    }

    private void Update()
    {
        Wave(Time.deltaTime);
    }

    private void Wave(float deltaTime)
    {
        transform.position = _axis.position + Vector3.up * Mathf.Sin(currentTime * frequency) * apperture;
        currentTime = currentTime + deltaTime;
    }
}
