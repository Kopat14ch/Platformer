
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _movementSpeed;
    [SerializeField] private int _jumpPower;
    [SerializeField] private LayerMask _groundLayerMask;
    
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private bool _canFlip;
    private bool _inRun;
    private bool _isGrounded;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        if (_groundLayerMask.value == 1 << gameObject.layer)
            Debug.LogError("ChangeLayerMask!!");
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * _movementSpeed, _rigidbody2D.velocity.y);

        if (_rigidbody2D.velocity.x == 0)
        {
            _inRun = false;
            _animator.SetBool("Run", _inRun);
        }
        else
        {
            _inRun = true;
            _animator.SetBool("Run", _inRun);
        }
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0 && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _animator.SetBool("IsJumping", true);
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetGround(collision, true);
        SetJumpAnimation(collision, false);
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

    private void SetJumpAnimation(Collision2D collision, bool value)
    {
        if (1 << collision.gameObject.layer == _groundLayerMask.value)
        {
            _animator.SetBool("IsJumping", value);
        }
    }
}
