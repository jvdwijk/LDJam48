using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    private Rigidbody2D wormRigidBody;

    [SerializeField]
    private float wormSpeed = 10;
    [SerializeField]
    private float rotateSpeed = 10;
    private float speedMult = 1;

    public float WormSpeed
    {
        get { return wormSpeed; }
        set { wormSpeed = value; }
    }

    public float RotateSpeed
    {
        get { return rotateSpeed; }
        set { rotateSpeed = value; }
    }


    private void Start() {
        wormRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        wormRigidBody.velocity = -transform.up * wormSpeed * speedMult;

        if (PlayerPrefs.GetInt("controllerType") == (int) ControllerTypes.Controller)
            ControllerMovement();
        else
            MouseMovement();

    }

    private void MouseMovement()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 wormPosition = Camera.main.WorldToScreenPoint(transform.position);
        float signedEngel = Vector2.SignedAngle(transform.up, wormPosition - mousePosition);

        transform.Rotate(0, 0, signedEngel > 0 ? Mathf.Min(signedEngel, rotateSpeed * Time.deltaTime) 
            : Mathf.Max(signedEngel, -rotateSpeed * Time.deltaTime));
    }

    private void ControllerMovement()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        if (horizontalAxis != 0)
        {
            float currentRotation = transform.localRotation.z;

            transform.Rotate(0, 0, -horizontalAxis * rotateSpeed * Time.deltaTime);
        }
    }

    public void multSpeed(float input)
    {
        speedMult *= input;
    }

    public void resetSpeedMult(float input)
    {
        speedMult = 1;
    }
}
