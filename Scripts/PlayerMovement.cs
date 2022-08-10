using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _playerSpeed = 15f;

    private Vector2 _rawInput;
    private Vector2 _minBounds;
    private Vector2 _maxBounds;

    private float _paddingLeft = 0.5f;
    private float _paddingRight = 0.5f;
    private float _paddingTop = 8f;
    private float _paddingBottom = 2f;

    private Shooter _shooter;

    void Awake()
    {
        _shooter = FindObjectOfType<Shooter>();
    }

    void Start()
    {
        InitBounds();
    }
    void Update()
    {
        Move();
    }
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

    }
    void Move()
    {
        Vector3 delta = _rawInput * _playerSpeed * Time.deltaTime;
        Vector2 currentPosition = new Vector2();
        currentPosition.x = Mathf.Clamp(transform.position.x + delta.x, _minBounds.x + _paddingLeft, _maxBounds.x - _paddingRight);
        currentPosition.y = Mathf.Clamp(transform.position.y + delta.y, _minBounds.y + _paddingBottom, _maxBounds.y - _paddingTop);
        transform.position = currentPosition;
    }
    void OnMove(InputValue value)
    {
        _rawInput = value.Get<Vector2>();
    }
    void OnFire(InputValue value)
    {
        if (_shooter != null)
        {
            _shooter.isFiring = value.isPressed;
        }
    }
}
