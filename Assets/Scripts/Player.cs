using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action<bool> Dead;
    private bool _isDead = false;

    public void OnDead()
    {
        _isDead = true;
        Dead?.Invoke(_isDead);
    }
}