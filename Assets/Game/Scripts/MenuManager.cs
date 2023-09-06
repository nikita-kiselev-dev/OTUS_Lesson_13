using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    enum Screen
    {
        None,
        Menu,
        Levels,
        Game
    }

    [SerializeField] private LevelMenuController levelMenuController;

    public CanvasGroup mainScreen;
    public CanvasGroup settingsScreen;

    private void Start()
    {
        SetCurrentScreen(Screen.Menu);
        levelMenuController.CreateLevelButtons();
    }

    private void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(mainScreen, screen == Screen.Menu);
        Utility.SetCanvasGroupEnabled(settingsScreen, screen == Screen.Levels);
    }

    public void StartNewGame()
    {
        SetCurrentScreen(Screen.Game);
        if (levelMenuController.GameScenes[0])
        {
            string sceneName = levelMenuController.GameScenes[0].name;
            SceneManager.LoadScene(sceneName);
        }
    }

    public void OpenSettings()
    {
        SetCurrentScreen(Screen.Levels);
    }

    public void CloseLevels()
    {
        SetCurrentScreen(Screen.Menu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
