using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speedMove; 
    private int desiredLane = 1;
    public float laneDistance = 4;
    public float jumpForce;
    private bool isJump = false;
    public Rigidbody rb ;
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Up speed
        GameManager.Instance.distance = (int)transform.position.z;
        if(GameManager.Instance.distance % 5 == 0 ) speedMove += Time.deltaTime;

        //Jump
        // giảm thời gian trên không ?
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isJump == false) Jump();
        }
        if(rb.velocity.y == 0) isJump = false;
        if(isJump == true) return;

        //Turn Left/Right
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if(desiredLane == 3) desiredLane = 2;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if(desiredLane == -1) desiredLane = 0;
        }
        Vector3 targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(desiredLane == 0)
        {
            targetPos += Vector3.left * laneDistance;
        }else if(desiredLane == 2)
        {
            targetPos += Vector3.right * laneDistance;
        }

        //Go Forward
        transform.position = Vector3.Lerp(transform.position,targetPos,1000f);
    }

    private void Jump()
    {
        rb.velocity += new Vector3(0,jumpForce,0);
        isJump = true;
    }

    private void FixedUpdate() {
        transform.position += Vector3.forward * speedMove * Time.deltaTime;
    }
}
