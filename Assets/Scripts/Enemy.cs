using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _movementSpeed;
    [SerializeField] private float _flipDelay;

    private Rigidbody2D _rigidbody2D;
    private Coroutine _changeDirectionJob;
    private bool _canChange;

    private void Start()
    {
        _canChange = true;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _changeDirectionJob = StartCoroutine(ChangeDirection());
    }

    private void OnDisable()
    {
        _canChange = false;
        StopCoroutine(_changeDirectionJob);
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_movementSpeed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);
    }


    private IEnumerator ChangeDirection()
    {
        while (_canChange)
        {
            _movementSpeed *= -1;
            
            
            yield return new WaitForSeconds(_flipDelay);
        }
    }
    
}
