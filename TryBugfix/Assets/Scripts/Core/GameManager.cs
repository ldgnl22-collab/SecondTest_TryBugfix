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
    // [Bug-06] 원인 : 싱클톤의 단 하나만 존재할 수 있게하는 처리를 하지 않았습니다
    // / 수정 : 'Instance'에 'GameManager'가 단 한번 들어가도록 코드 수정
    private void SetSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
