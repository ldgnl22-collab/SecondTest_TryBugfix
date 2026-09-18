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
    // [Bug-07] 원인 : 해당 스크립트가 비활성화 될때 걸려있는
    // 이벤트 해제를 하지 않아 활성화 할때마다 동일한 이벤트가 누적되었습니다
    // / 수정 : 해당 스크립트 비활성화 시 걸려있는 이벤트를 해제하는 코드 작성
    private void UnBindWalletEvents()
    {
        _wallet.OnCoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected()
    {
        _collectedCount++;
        UpdateText();
    }

    private void OnDisable()
    {
        UnBindWalletEvents();
    }

    private void UpdateText()
    {
        _coinText.text = $"COIN {_collectedCount}";
    }
}
