using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speedMovement = 7f;
    [SerializeField] private float _forceJump = 500f;
    [SerializeField] private float _groundCheckDistance = 1.1f;
    [SerializeField] private Transform _startPoint;
    private Rigidbody _rigidbody;
    private bool _isGrounded;

    private void Awake()
    {
        Player.Dead += OnDead;    
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        transform.position = _startPoint.position;
    }

    private void Update()
    {
        CheckGround();
        Move();
        ResetPos();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal") * Time.deltaTime * _speedMovement;
        Vector3 direction = new Vector3(xInput, 0, 0);

        transform.Translate(direction);
    }

    private void CheckGround()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance);
        Debug.DrawRay(transform.position, Vector3.down * _groundCheckDistance, Color.cyan);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _forceJump);
    }

    private void ResetPos()
    {
        if (transform.position.y < - 10f)
        {
            transform.position = _startPoint.position;
        }
    }

    private void OnDead(bool obj)
    {
        this.enabled = false;
    }
}