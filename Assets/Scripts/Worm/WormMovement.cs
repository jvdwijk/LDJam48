using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    private Rigidbody2D wormRigidBody;

    [SerializeField]
    private float upBorder, leftBorder, rightBorder;


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

        if (transform.position.x < -leftBorder)
        {
            MoveRight();
        }
        else if (transform.position.x > rightBorder)
        {
            MoveLeft();
        }
        else if((transform.position.y > upBorder && PlayerPrefs.GetInt("worm_skin_Space Jimdinant") > 0) 
            && SkinManager.Instance.Current.Name != "Space Jimdinant")
        {
            MoveDown();
        }
        else if (PlayerPrefs.GetInt("controllerType") == (int) ControllerTypes.Controller)
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
            var rotation = -horizontalAxis * rotateSpeed * Time.deltaTime;
            var inverseMovement = PlayerPrefs.GetInt(PlayerPrefKeys.INVERSE_MOVEMENT, 0) != 0;
            if(inverseMovement){
                rotation *= -1;
            }
            transform.Rotate(0, 0, rotation);
        }
    }

    private void MoveDown()
    {
        Vector3 wormPosition = transform.position;
        float signedEngel = Vector2.SignedAngle(transform.up, -Vector3.down);

        transform.Rotate(0, 0, Mathf.Max(Mathf.Min(signedEngel, rotateSpeed * Time.deltaTime), -rotateSpeed * Time.deltaTime));
    }

    private void MoveRight()
    {
        Vector3 wormPosition = transform.position;
        float signedEngel = Vector2.SignedAngle(transform.up, -Vector3.right - Vector3.down);

        transform.Rotate(0, 0, Mathf.Max(Mathf.Min(signedEngel, rotateSpeed * Time.deltaTime), -rotateSpeed * Time.deltaTime));
    }

    private void MoveLeft()
    {
        Vector3 wormPosition = transform.position;
        float signedEngel = Vector2.SignedAngle(transform.up, -Vector3.left - Vector3.down);

        transform.Rotate(0, 0, Mathf.Max(Mathf.Min(signedEngel, rotateSpeed * Time.deltaTime), -rotateSpeed * Time.deltaTime));
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
