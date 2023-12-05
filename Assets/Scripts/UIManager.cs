using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameoverText;
    [SerializeField] private GameObject _winText;
    [SerializeField] private TextMeshProUGUI _coinText;

    private void Awake()
    {
        WalletCoin.CollectedCoin += OnCollectedCoin;
        WalletCoin.FullWallet += OnGameWin;
        Player.Dead += OnGameOver;
    }

    private void Start()
    {
        DisableText(_winText);
        DisableText(_gameoverText);
    }

    private void OnCollectedCoin(int currentCoin, int maxCoint)
    {
        _coinText.text = $"{currentCoin}/{maxCoint}";

        if(currentCoin == maxCoint)
        {
            EnableText(_winText);
        }
    }

    private void OnGameOver(bool dead)
    {
        if (dead)
        {
            EnableText(_gameoverText);
        }
    }

    private void OnGameWin()
    {
        EnableText(_winText);
    }

    private void EnableText(GameObject panel)
    {
        panel.SetActive(true);
    }

    private void DisableText(GameObject panel)
    {
        panel.SetActive(false);
    }
}