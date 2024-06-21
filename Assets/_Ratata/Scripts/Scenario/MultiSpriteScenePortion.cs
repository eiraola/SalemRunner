using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSpriteScenePortion : ScenePortionBase
{
    [SerializeField] private Transform _initPoint;
    [SerializeField] private Transform _endPoint;
    public override Vector3 GetEndPoint()
    {
        return _initPoint.position;
    }

    public override Vector3 GetInitPoint()
    {
        return _endPoint.position;
    }
}
