using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameSessionManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject menu;
    [SerializeField] private TMP_Text menuText;
    private GameStartManager gameStartManager;
  //  [SerializeField] GameObject playerControllerObject;
    [SerializeField] private PlayerInput playerInput;
    public bool isPaused;

    private void Awake()
    {
        gameStartManager = GetComponent<GameStartManager>();
        PlayerStateMachineManager.onDead += onDeathOrWin;
        GameStartManager.gameWon += onDeathOrWin;
    }


    private void OnDestroy()
    {
        Debug.Log("Újraindítás...");
        PlayerStateMachineManager.onDead -= onDeathOrWin;
        GameStartManager.gameWon -= onDeathOrWin;
    }

    private void Start()
    {
        Debug.Log("Game Session On Game Start");

        isPaused = false;
        menu.SetActive(false);
    }

    private void onDeathOrWin()
    {
        Debug.Log("Haltam");
        Cursor.lockState = CursorLockMode.None;
        menu.SetActive(true);
        Debug.Log("Menü állapota amiután aktiválni kellene: " + menu.activeSelf);
        if (gameStartManager.totalZombieKills.Equals(gameStartManager.enemyNum))
        {
            menuText.SetText("Congratulations!");
        }
        else
        {
            menuText.SetText("You Lost!");
        }
        Debug.Log("Menü állapota: "+menu.activeSelf);
    }

    public void OnPauseBtnPressed()
    {
        Debug.Log("Pause nyomva?");
        menu.SetActive(!menu.activeSelf);
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            isPaused = false;
            Debug.Log("Unpaused");
            Time.timeScale = 1f;
           // InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            menuText.SetText("Paused");
            isPaused = true;
            Debug.Log("Paused");
            Time.timeScale = 0f;
         //   InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
        }
    }
}
