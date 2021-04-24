using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    private Transform worm;
    private Rigidbody2D wormRigidBody;

    [SerializeField]
    private float wormSpeed = 10;
    [SerializeField]
    private float rotateSpeed = 10;


    private void Start() {
        worm = GetComponent<Transform>();
        wormRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        wormRigidBody.velocity = -worm.up * wormSpeed;
        if (horizontalAxis != 0)
        {
            float currentRotation = worm.localRotation.z;

            worm.Rotate(0, 0, horizontalAxis * rotateSpeed * Time.deltaTime);

        }

    }
}
