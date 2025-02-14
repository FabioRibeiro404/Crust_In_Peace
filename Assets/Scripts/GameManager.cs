using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private NPCSpawner spawner;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        NPCDefeated();
    }

    public void NPCDefeated()
    {
        if (spawner.npcRemoved <= 0)
            gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}