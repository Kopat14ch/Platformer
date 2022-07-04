using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Player _player;

    private void SetJumpAnimation(Collision2D collision, bool value)
    {
        if (1 << collision.gameObject.layer == _player.GroundLayerMask.value)
        {
            _animator.SetBool(AnimatorPlayerController.Params.IsJumping, value);
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
        
        if (_player.GroundLayerMask.value == 1 << gameObject.layer)
            Debug.LogError("ChangeLayerMask!!");
    }

    private void Update()
    {
        SetRunAnimation();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetJumpAnimation(collision, false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        SetJumpAnimation(collision, true);
    }

    private void SetRunAnimation()
    {
        if (_player.Rigidbody2D.velocity.x == 0)
        {
            _animator.SetBool(AnimatorPlayerController.Params.Run, false);
        }
        else
        {
            _animator.SetBool(AnimatorPlayerController.Params.Run, true);
        }
    }
}
