using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset = new Vector3(0,0,-10);
    [SerializeField] private float _lerpRate = 1f;

    private void LateUpdate()
    {
        float timeRate = Time.deltaTime * _lerpRate;

        Vector3 targetPosition =  _player.transform.position + _offset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, timeRate);
    }
}