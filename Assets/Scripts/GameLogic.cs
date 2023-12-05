using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    private bool isDead = false;
    private bool isWinned = false;

    private void Awake()
    {
        Player.Dead += OnDead;
        WalletCoin.FullWallet += OnWin;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            if (isDead || isWinned)
            {
                SceneManager.LoadScene("Level");
            }
        }
    }

    private void OnDead(bool isdead)
    {
        isDead = isdead;
    }

    private void OnWin()
    {
        isWinned = true;
    }
}