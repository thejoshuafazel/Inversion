﻿using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float _jumpSpeed = 10f;
    [SerializeField] LayerMask _platformLayerMask;
    
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;
    private BoxCollider2D _boxCollider;
    private bool _jump;

    private void Start()
    {
        CacheData();
        UpdatePlayerSprite();
    }

    private void FixedUpdate()
    {
        Move();
        JumpAndInvert();
    }

    private void Update()
    {
        ReadInput();
    }

    private void CacheData()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycatHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f,
                                                    Vector2.down, extraHeight, _platformLayerMask);

        //-------------Code for debugging only
        //Color raycolor;
        //if (raycatHit.collider != null)
        //{
        //    raycolor = Color.green;
        //}
        //else
        //{
        //    raycolor = Color.red;
        //}
        //Debug.DrawRay(_boxCollider.bounds.center + new Vector3(_boxCollider.bounds.extents.x, 0), Vector2.down * (_boxCollider.bounds.extents.y + extraHeight), raycolor);
        //Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x, 0), Vector2.down * (_boxCollider.bounds.extents.y + extraHeight), raycolor);
        //Debug.DrawRay(_boxCollider.bounds.center - new Vector3(_boxCollider.bounds.extents.x, _boxCollider.bounds.extents.y + extraHeight), Vector2.right * (_boxCollider.bounds.extents.x * 2f), raycolor);
        //-------Can remove after playtesting

        return raycatHit.collider != null;
    }

    private void ReadInput()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _jump = true;
        }
    }

    private void UpdatePlayerSprite()
    {
        //if (_normalWorld)
        //{
        //    _spriteRenderer.color = Color.white;
        //}
        //else
        //{
        //    _spriteRenderer.color = Color.black;
        //}
    }

    private void JumpAndInvert()
    {
        if (_jump)
        {
            Jump();
            Invert();

            Debug.Log("Player was grounded and jumped. World should be inverted");
        }
    }

    private void Jump()
    {
        _rigidBody.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);
        _jump = false;
    }

    private void Move()
    {
        var movementX = Input.GetAxis("Horizontal")  * Time.deltaTime * _moveSpeed;
        transform.position = new Vector2(transform.position.x + movementX, transform.position.y);
    }

    private void Invert()
    {
        _gameManager.LoadNextWorld();
        UpdatePlayerSprite();
    }
}
