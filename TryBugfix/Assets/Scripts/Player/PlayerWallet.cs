using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private int _coinCount;

    public int CoinCount => _coinCount;
    
    public event Action OnCoinCollected;
    
    public void Collect()
    {
        _coinCount++;

        if (OnCoinCollected != null)
        {
            OnCoinCollected.Invoke();
        }
    }
}
