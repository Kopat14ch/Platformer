using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(Flip))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _movementSpeed;
    [SerializeField] private int _jumpPower;
    [SerializeField] private LayerMask _groundLayerMask;

    private Rigidbody2D _rigidbody2D;
    private PlayerAnimation _playerAnimation;
    private bool _canFlip;
    private bool _isGrounded;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public LayerMask GroundLayerMask => _groundLayerMask;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * _movementSpeed, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0 && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetGround(collision, true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        SetGround(collision, false);
    }

    private void SetGround(Collision2D collision, bool value)
    {
        if (1 << collision.gameObject.layer == _groundLayerMask.value)
        {
            _isGrounded = value;
        }
    }
}