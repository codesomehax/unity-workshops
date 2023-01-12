using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsScript : MonoBehaviour
{
    private Animator _animator;

    private static bool IsWalking =>
        Mathf.Abs(Input.GetAxis("Horizontal")) >= 0.1 ||
        Mathf.Abs(Input.GetAxis("Vertical")) >= 0.1;

    // private static bool IsRunning => IsWalking && Input.GetKey(KeyCode.LeftShift);

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool("IsWalking", IsWalking);
    }
}
