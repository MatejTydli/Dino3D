using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody playerBody;
    public Camera playerCamera;

    public float moveForceValue;
    public float jumpForceValue;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float jumpAxis = Input.GetAxis("Jump");

        playerBody.transform.rotation = Quaternion.identity;

        Vector3 moveForceVector = new Vector3(horizontalAxis * moveForceValue, 0, 0);
        playerBody.AddForce(moveForceVector);

        if ((jumpAxis > 0 || Input.GetKey(KeyCode.W)) && playerBody.transform.position.y <= 1.2f && playerBody.transform.position.y > 0)
        {
            Vector3 jumpForceVector = new Vector3(0, jumpAxis * jumpForceValue, 0);
            playerBody.AddForce(jumpForceVector);
        }

        playerCamera.transform.position = new Vector3
            (playerBody.transform.position.x, playerBody.transform.position.y + 1f, playerBody.transform.position.z - 5f);
    }
}