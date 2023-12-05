using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private Player _player;
    private WalletCoin _walletCoin;

    private void Start()
    {
        _player = GetComponent<Player>();
        _walletCoin = GetComponent<WalletCoin>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Enemy>())
        {
            _player.OnDead();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Coin>())
        {
            Destroy(other.gameObject);
            _walletCoin.AddCoin();
        }
    }
}