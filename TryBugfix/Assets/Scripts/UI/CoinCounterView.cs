using UnityEngine;
using TMPro;

public class CoinCounterView : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private TextMeshProUGUI _coinText;

    private int _collectedCount;

    private void OnEnable()
    {
        BindWalletEvents();
    }

    private void Start()
    {
        UpdateText();
    }

    private void BindWalletEvents()
    {
        _wallet.OnCoinCollected += OnCoinCollected;
    }

    private void OnCoinCollected()
    {
        _collectedCount++;
        UpdateText();
    }

    private void UpdateText()
    {
        _coinText.text = $"COIN {_collectedCount}";
    }
}
