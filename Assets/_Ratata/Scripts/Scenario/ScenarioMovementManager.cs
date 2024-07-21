using UnityEngine;
using UnityEngine.Events;

public class ScenarioMovementManager : MonoBehaviour
{

    [SerializeField] private float _movementSpeed = 3.0f;
    [SerializeField] private UnityEvent<float> _onMovementDone = new UnityEvent<float>();
    [SerializeField] private FloatSignalSO _scenarioMovementSignalSO;
    [SerializeField] private ScenarioDataSO _scenarioDataSO;
    [SerializeField] private SoundSignalSO _bgmSignalSO;
    private float _currentMetters = 0.0f;

    private void Start()
    {
        _scenarioDataSO.Init();
        _bgmSignalSO.PlayClipSound(EClip.MainGame);
    }

    private void MoveScenario()
    {
        _onMovementDone?.Invoke(_movementSpeed * Time.deltaTime);
        _currentMetters += _movementSpeed * Time.deltaTime;
        _scenarioMovementSignalSO.ChangeValue(_movementSpeed * Time.deltaTime);
    }

    private void Update()
    {
        MoveScenario();
    }
}
