using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Flip : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private bool _isFlip;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Change();
    }

    private void Change()
    {
        float minVelocityValue = -0.0001f;
        
        _spriteRenderer.flipX = _rigidbody2D.velocity.x < minVelocityValue;
    }
}
