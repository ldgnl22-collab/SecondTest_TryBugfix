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
    // [Bug-09] 원인 : 재시작하는 코드에 시간정지를 풀어주지 않았습니다 / 수정 : 시간을 움직이는 코드 추가
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SCENE_GAME);
    }

    private void InitRound()
    {
        GameManager.Instance.ResetScore();
        _gameOverPanel.SetActive(false);
    }
}
