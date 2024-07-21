using UnityEngine;

[CreateAssetMenu(fileName = "New Scenario Data", menuName = "ScriptableObjects/Data/Scenario Data", order = 2)]
[System.Serializable]

public class ScenarioDataSO : ScriptableObject
{
    private Vector3 _startPosition = Vector3.zero;
    private Vector3 _endPosition = Vector3.zero;

    public Vector3 StartPosition { get => _startPosition; }
    public Vector3 EndPosition { get => _endPosition;  }

    public void Init()
    {
        Camera cam = Camera.main;

        float cameraHeight = cam.orthographicSize * 2;
        float cameraWidth = cameraHeight * cam.aspect;

        _endPosition.x = cam.transform.position.x - cameraWidth / 2;
        _startPosition.x = cam.transform.position.x + cameraWidth / 2;
    }
}
