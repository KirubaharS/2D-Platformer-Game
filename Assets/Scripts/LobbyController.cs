using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public GameObject LevelSelection;
    public Button buttonPlay;
    public Button buttonQuit;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
        buttonPlay.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        LevelSelection.SetActive(true);        
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
