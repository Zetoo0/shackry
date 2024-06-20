using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField]private GameObject _helpObject;



    public void ExitGame()
    {
        Debug.Log("Exit clicked");
        Application.Quit();
    }

    public void BackToMenu()
    {
        Debug.Log("Nyomva");

        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void PlayGame()
    {
        Debug.Log("Nyomva");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Restart()
    {
        Debug.Log("Nyomva");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void HelpOn()
    {
        _helpObject.SetActive(true);
    }

    public void HelpOff()
    {
        _helpObject.SetActive(false);
    }
}
