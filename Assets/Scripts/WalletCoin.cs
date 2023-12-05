using System;
using UnityEngine;

public class WalletCoin : MonoBehaviour
{
    public static Action<int, int> CollectedCoin;
    public static Action FullWallet;

    private int _currentCoin = 0;
    private int _maxCoin;
    private Coin[] _coins;

    private void Start()
    {
        _coins = FindObjectsOfType<Coin>();
        _maxCoin = _coins.Length;

        CollectedCoin?.Invoke(_currentCoin, _maxCoin);
    }

    public void AddCoin()
    {
        _currentCoin++;
        CollectedCoin?.Invoke(_currentCoin, _maxCoin);

        if(_currentCoin >= _maxCoin) FullWallet?.Invoke();
    }
}