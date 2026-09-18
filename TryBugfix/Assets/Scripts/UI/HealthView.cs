using UnityEngine;
using TMPro;

public class HealthView : MonoBehaviour
{
    private TextMeshProUGUI _healthText;

    public void Show(int health)
    {
        _healthText.text = $"HP {health}";
    }
}
