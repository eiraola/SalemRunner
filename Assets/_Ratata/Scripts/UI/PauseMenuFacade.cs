using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuFacade : MonoBehaviour
{
    [SerializeField] private PauseMenuAnimator _pauseMenuAnimator;
    [SerializeField] private PauseMenuAnimator _dieMenuAnimator;
    [SerializeField] private GameObject _systemMenuGO;
    [SerializeField] private SceneSignalSender _sceneSignalSender;
    [SerializeField] private PauseSignalSO _pauseSignalSO;
    [SerializeField] private DieSignalSO _dieSignalSO;
    private PauseMenuAnimator _currentAnimator = null;
    private Action _onCloseMenuAction = null;
    private bool _isOpen = false;
    private void OnEnable()
    {
        _pauseSignalSO.onGamePause.AddListener(PauseGame);
        _dieSignalSO.onDieEvent.AddListener(PauseDead);
    }

    private void PauseGame()
    {
        if (_isOpen)
        {
            return;
        }
        _isOpen = true;
        Time.timeScale = 0.0f;
        _currentAnimator = _pauseMenuAnimator ;
        OpenMenu();
    }

    private void PauseDead()
    {
        if (_isOpen)
        {
            return;
        }
        _isOpen = true;
        Time.timeScale = 0.0f;
        _currentAnimator = _dieMenuAnimator;
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
        _systemMenuGO.SetActive(true);
        _currentAnimator.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        _currentAnimator.ExitMenuAnimation(OnMenuClosed);
    }

    private void OnMenuClosed()
    {
        _currentAnimator.gameObject.SetActive(false);
        _systemMenuGO.SetActive(false);
        _onCloseMenuAction?.Invoke();
        _onCloseMenuAction = null;
    }

    private void ResumeGameTime()
    {
        Time.timeScale = 1.0f;
        _isOpen = false;
    }

    private void GoBackToMenu()
    {
        _sceneSignalSender.OpeMenuScene();
        _isOpen = false;
    }
}
