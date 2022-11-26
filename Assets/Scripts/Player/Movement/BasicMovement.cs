using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // vector          +=  scalar             scalar           vector
            transform.position +=  movementSpeed * Time.deltaTime * transform.forward;
        }
        
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // vector          +=  scalar             scalar           vector
            transform.position -=  movementSpeed * Time.deltaTime * transform.forward;
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // vector          +=  scalar             scalar           vector
            transform.position -=  movementSpeed * Time.deltaTime * transform.right;
        }
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // vector          +=  scalar             scalar           vector
            transform.position +=  movementSpeed * Time.deltaTime * transform.right;
        }
    }
}