using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EScenes
{
    None,
    MainMenu,
    Game
}

public class SceneLoader : MonoBehaviour
{
    private EScenes _currentScene = EScenes.None;
    AsyncOperation asyncLoad = null;

    public void LoadScene(EScenes scene, Action onFinishLoad = null) 
    {
        if (_currentScene != EScenes.None)
        {
            UnLoadScene(_currentScene);
        }
        _currentScene = scene;
        StartCoroutine(LoadSceneAsync(scene, onFinishLoad));
        
    }

    private void UnLoadScene(EScenes scene)
    {
        SceneManager.UnloadSceneAsync(Constants.SceneName(_currentScene));
    }

    private IEnumerator LoadSceneAsync(EScenes scene, Action onFinishLoad = null)
    {
        asyncLoad = SceneManager.LoadSceneAsync(Constants.SceneName(_currentScene), LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        onFinishLoad?.Invoke();
    }
}
