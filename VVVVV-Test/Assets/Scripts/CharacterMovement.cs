using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class CharacterMovement : MonoBehaviour
{
    private Animator _animator;
    private Transform _transform;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;


    private float _horizontal;
    private float _speed;
    private int _gravity;
    private bool _isFacingRight;
    

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();

        _speed = 18f;
        _gravity = 8;
        _rb.gravityScale = _gravity;
        _isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        _horizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
        Flip();

        //Cambio de gravedad
        if ((UnityEngine.Input.GetKeyDown(KeyCode.Space) || UnityEngine.Input.GetKeyDown(KeyCode.Joystick1Button0)) && IsGrounded())
        {
            _isFacingRight = !_isFacingRight;
            _transform.Rotate(0, 0, 180);
            _gravity *= -1;
            _rb.gravityScale = _gravity;
        }

        //AnimacionMovimiento
        if (_horizontal != 0) _animator.SetBool("isMoving", true);
        else _animator.SetBool("isMoving", false);

        //AnimacionCaida
        if (IsGrounded()) _animator.SetBool("isFalling", false);
        else _animator.SetBool("isFalling", true);
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }
    private void Flip()
    {
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}