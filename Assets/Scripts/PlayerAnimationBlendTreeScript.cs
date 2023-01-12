using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBlendTreeScript : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float speed = _rigidbody.velocity.magnitude;
        
        _animator.SetFloat("Speed", speed);
    }
}
