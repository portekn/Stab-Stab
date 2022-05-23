using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerMoveSpeed = 5.0f;
    public float playerRotateSpeed = 50f;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = transform.TransformDirection(Vector3.forward);
        //move forward
        if(Input.GetAxis("Vertical") > 0)
        {
            controller.Move(moveDir * Time.deltaTime * playerMoveSpeed);
        }
        //move backward
        else if (Input.GetAxis("Vertical") < 0)
        {
            controller.Move(-moveDir * Time.deltaTime * playerMoveSpeed);
        }
        //rotate left
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * playerRotateSpeed);
        }
        //rotate right
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * playerRotateSpeed);
        }
        //gravity affects player
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

}
