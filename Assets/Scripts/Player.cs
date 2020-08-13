using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float _jumpSpeed = 10f;
    [SerializeField] bool _normalWorld;

    InvertedUI _invertedUI;
    NormalUI _normalUI;
    Rigidbody2D _rigidBody;
    SpriteRenderer _spriteRenderer;

    private void UpdateWorldFlag() => _normalWorld = _normalWorld ? false : true;

    private void Start()
    {
        _invertedUI = FindObjectOfType<InvertedUI>();
        _normalUI = FindObjectOfType<NormalUI>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        SetActiveWorldGameobjects();
        UpdatePlayerSprite();
    }

    private void UpdatePlayerSprite()
    {
        if (_normalWorld)
        {
            _spriteRenderer.color = Color.white;
        }
        else
        {
            _spriteRenderer.color = Color.black;
        }
    }

    private void Update()
    {
        Invert();
        Move();
    }
    
    private void SetActiveWorldGameobjects()
    {
        if (_normalWorld)
        {
            _invertedUI.gameObject.SetActive(false);
            _normalUI.gameObject.SetActive(true);
        }
        else
        {
            _invertedUI.gameObject.SetActive(true);
            _normalUI.gameObject.SetActive(false);
        }
    }

    private void Invert()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space was pressed. World should be inverted");

            UpdateWorldFlag();
            SetActiveWorldGameobjects();
            UpdatePlayerSprite();
            Jump();
        }
    }

    private void Jump()
    {
        if(Mathf.Approximately(_rigidBody.velocity.y ,0f))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, _jumpSpeed);
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal")  * Time.deltaTime * _moveSpeed;

        transform.position = new Vector2(transform.position.x + deltaX, transform.position.y);
    }
}
