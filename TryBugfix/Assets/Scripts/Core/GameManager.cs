using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score;

    public static GameManager Instance { get; private set; }

    public int Score => _score;

    private void Awake()
    {
        SetSingleton();
    }

    public void AddScore(int amount)
    {
        _score += amount;
        _scoreText.text = $"SCORE {_score}";
    }

    public void ResetScore()
    {
        _score = 0;
    }

    private void SetSingleton()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
