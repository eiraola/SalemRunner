using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeFacade : MonoBehaviour
{
    [SerializeField] private ScreenFader _screenFader;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] SceneSignalSO _signalSO;
    [SerializeField] EScenes _initScene = EScenes.MainMenu;
    private EScenes _newScene = EScenes.None;

    private void Start()
    {
        DOTween.Init();
        DOTween.defaultTimeScaleIndependent = true;
        _signalSO.onSceneChangeSignalSended.AddListener(StartChangingScene);
        SimpleLoad(_initScene);
    }

    public void StartChangingScene(EScenes newScene)
    {
        _newScene = newScene;
        _screenFader.FadeOut(ChangeScene);
    }

    private void ChangeScene()
    {
        _sceneLoader.LoadScene(_newScene, FinishSceneChange);
    }

    private void FinishSceneChange()
    {
        _screenFader.FadeIn();
    }

    private void SimpleLoad(EScenes sceneName)
    {
        _screenFader.SetBlackScreen();
        _sceneLoader.LoadScene(sceneName, FinishSceneChange);
    }
}
