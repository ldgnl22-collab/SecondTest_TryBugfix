using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    private const string SCENE_GAME = "Game";

    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        InitRound();
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        _gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SCENE_GAME);
    }

    private void InitRound()
    {
        GameManager.Instance.ResetScore();
        _gameOverPanel.SetActive(false);
    }
}
