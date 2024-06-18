using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SceneManagement", order = 1)]
[System.Serializable]
public class SceneSignalSO : ScriptableObject
{
    public UnityEvent<EScenes> onSceneChangeSignalSended = new UnityEvent<EScenes>();

    public void SendSceneChangeSignal(EScenes newScene)
    {
        onSceneChangeSignalSended.Invoke(newScene);
    }

    private void OnEnable()
    {
        onSceneChangeSignalSended.RemoveAllListeners();
    }

}

