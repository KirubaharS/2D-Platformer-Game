using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonLobby;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonLobby.onClick.AddListener(GoToLobby);
    }
    public void PlayerDied ()
    {
        SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
        gameObject.SetActive (true);

    }

    private void GoToLobby () 
    {
        SceneManager.LoadScene(0);
    }

    private void ReloadLevel ()
    {
        Debug.Log("Reload scene 0");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
