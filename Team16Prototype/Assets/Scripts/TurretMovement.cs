using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretMovement : MonoBehaviour
{
    private float turnSmoothTime = 0.5f;
    private float turnSmoothVelocity;
    private bool canMove = true;
    public Transform cam;
    private Vector3 direction;
    public CharacterController controller;
    public float playerSpeed = 6f;

    void Update()
    {
        if (canMove)
        {
            float horizontal = Input.GetAxisRaw("VerticalRight");
            float vertical = Input.GetAxisRaw("HorizontalRight");
            direction = new Vector3(horizontal, 0f, vertical).normalized;
        }
        //smooths out turning
        if (direction.magnitude >= 0.1f && canMove)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(270f, angle, 0f);

        }
    }
}