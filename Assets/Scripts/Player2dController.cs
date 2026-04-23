using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2dControler : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 450f;

    private Rigidbody2D _rb;
    private float _moveInput;
    private bool _isGrounded = false;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = _rb.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current != null)
        {
            _moveInput = (Keyboard.current.dKey.isPressed ? 1 : 0) - (Keyboard.current.aKey.isPressed ? 1 : 0);
        }
        _rb.linearVelocity = new Vector2(_moveInput * speed, _rb.linearVelocity.y);

        if (_moveInput < 0) { _spriteRenderer.flipX = true; }
        else if (_moveInput > 0) { _spriteRenderer.flipX = false; }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && _isGrounded)
        {
            _rb.AddForce(new Vector2(_rb.linearVelocity.x, jumpForce));
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
    private void OnCollisionStay2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
    private void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}
