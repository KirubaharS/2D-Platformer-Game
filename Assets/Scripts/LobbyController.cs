using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public Button buttonQuit;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
        buttonPlay.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }



    private void QuitGame()
    {
        Application.Quit();
    }
}
