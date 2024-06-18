using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuFacade : MonoBehaviour
{
    [SerializeField] private PauseMenuAnimator _pauseMenuAnimator;
    [SerializeField] private GameObject _pauseMenuGO;
    [SerializeField] private SceneSignalSender _sceneSignalSender;
    [SerializeField] private PauseSignalSO _pauseSignalSO;
    private Action _onCloseMenuAction = null;
    private void OnEnable()
    {
        _pauseSignalSO.onGamePause.AddListener(PauseGame);
    }

    private void PauseGame()
    {
        Time.timeScale = 0.0f;
        OpenMenu();
    }

    public void ResumeGame()
    {
        _onCloseMenuAction = ResumeGameTime;
        CloseMenu();
    }

    public void GoToMainMenu()
    {
        _onCloseMenuAction = GoBackToMenu;
        CloseMenu();
    }

    public void OpenMenu()
    {
        _pauseMenuGO.SetActive(true);
        _pauseMenuAnimator.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        _pauseMenuAnimator.ExitMenuAnimation(OnMenuClosed);
    }

    private void OnMenuClosed()
    {
        _pauseMenuAnimator.gameObject.SetActive(false);
        _pauseMenuGO.SetActive(false);
        _onCloseMenuAction?.Invoke();
        _onCloseMenuAction = null;
    }

    private void ResumeGameTime()
    {
        Time.timeScale = 1.0f;
    }

    private void GoBackToMenu()
    {
        _sceneSignalSender.OpeMenuScene();
    }
}
