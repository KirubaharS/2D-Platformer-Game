using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public string lobbySceneName = "Lobby"; // Name of your lobby scene

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player cleared the level");

            LevelManager.Instance.MarkCurrentLevelCompleted();

            string currentSceneName = SceneManager.GetActiveScene().name;
            int currentSceneIndex = System.Array.IndexOf(LevelManager.Instance.Levels, currentSceneName);
            int nextSceneIndex = currentSceneIndex + 1;

            if (nextSceneIndex < LevelManager.Instance.Levels.Length)
            {
                string nextSceneName = LevelManager.Instance.Levels[nextSceneIndex];
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                SceneManager.LoadScene(lobbySceneName);
            }
        }
    }
}