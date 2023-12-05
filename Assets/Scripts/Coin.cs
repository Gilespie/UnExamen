using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _maxSize = 1f;
    private Transform _size;

    private void Start()
    {
        _size = GetComponent<Transform>();
        _size.localScale = Vector3.one;
    }

    private void Update()
    {
        Pulsation();
    }

    private void Pulsation()
    {
        float speedTime = Time.time;

        float xNewSize = Mathf.PingPong(speedTime, _maxSize);
        float yNewSize = Mathf.PingPong(speedTime, _maxSize);
        float zNewSize = Mathf.PingPong(speedTime, _maxSize);

        Vector3 newSize = new Vector3(xNewSize, yNewSize, zNewSize);

        _size.localScale = newSize;
    }
}