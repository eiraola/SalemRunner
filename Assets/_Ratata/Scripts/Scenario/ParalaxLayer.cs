using System.Collections.Generic;
using UnityEngine;

public class ParalaxLayer : MonoBehaviour
{
    [SerializeField] private Transform _initPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private List<Transform> _paralaxElements;
    [SerializeField] private float _paralaxSpeed = 1.0f;

    public void MoveParalaxLayer(float speed)
    {
        foreach (Transform part in _paralaxElements)
        {
            part.position -= Vector3.right * speed * _paralaxSpeed * Time.deltaTime;
            if (part.position.x < _initPoint.position.x)
            {
                part.position = new Vector3(_endPoint.transform.position.x, part.position.y, part.position.z);
            }
        }
    }
}
