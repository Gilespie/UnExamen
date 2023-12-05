using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    [SerializeField] private float _checkDistance = 1f;
    [SerializeField] private Transform[] _targets;
    private int indexPoint = 0;

    private void Update()
    {
        CalculateDistance(_targets[indexPoint]);
        Move(_targets[indexPoint]);
    }

    private void Move(Transform target)
    {
        float speedTime = Time.deltaTime * _speedMovement;
        Vector3 direction = (target.transform.position - transform.position).normalized * speedTime;

        transform.Translate(direction);
    }

    private void CalculateDistance(Transform target)
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if(distance <= _checkDistance)
        {
            CalculateNextTarget();
        }
    }

    private void CalculateNextTarget()
    {
        if (indexPoint < _targets.Length) indexPoint++;
        if (indexPoint >= _targets.Length) indexPoint = 0;
    }
}