using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerSpeedMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    private CharacterController _characterController;
    private float _horizontalMovement;
    private float _verticalMovement;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 inputDirection = new Vector3(_horizontalMovement, 0f, _verticalMovement);
        Vector3 speedVector = transform.TransformDirection(inputDirection);
        
        _characterController.SimpleMove(movementSpeed * speedVector);
    }
}
