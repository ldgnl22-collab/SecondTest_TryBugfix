using UnityEngine;
using TMPro;

public class HealthView : MonoBehaviour
{
    private TextMeshProUGUI _healthText;
    
    private void Awake() => CacheComponents();
    
    public void Show(int health)
    {
        _healthText.text = $"HP {health}";
    }
    // [Bug-03] 원인 : '_healthText'필드에 있는 컴포넌트를 가져오지 않았습니다
    // / 수정 : 'GetComponent'로 컴포넌트 가져오기
    private void CacheComponents()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
    }
}
