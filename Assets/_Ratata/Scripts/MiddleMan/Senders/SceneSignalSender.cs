using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSignalSender : MonoBehaviour
{
    [SerializeField] private SceneSignalSO _sceneSignalSo;

    public void OpenGameScene()
    {
        SendSceneSignal(EScenes.Game);
    }

    public void OpeMenuScene()
    {
        SendSceneSignal(EScenes.MainMenu);
    }

    private void SendSceneSignal(EScenes scene)
    {
        _sceneSignalSo.SendSceneChangeSignal(scene);
    }
}
