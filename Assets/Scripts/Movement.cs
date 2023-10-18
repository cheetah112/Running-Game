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
    public Animator anim;
    private CapsuleCollider playerCollider;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        anim.SetBool("left",false);
        anim.SetBool("right",false);
        anim.SetBool("slide",false);
        speedMove = GameManager.Instance.speedMove;
        if(GameManager.Instance.isEndGame) 
        {
            speedMove = 0;
            return;
        }
        if(GameManager.Instance.isPauseGame) return;
        GameManager.Instance.distance = (int)transform.position.z;
        //Jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isJump == false) Jump();
        }
        if(rb.velocity.y == 0) 
        {
            isJump = false;
            anim.SetBool("IsJump", false);
        }
        if(isJump == true) return;
        //slide
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("slide", true);
            transform.position += Vector3.forward*2f*Time.deltaTime;
            StartCoroutine(Slide());
        }
        //Turn Left/Right
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if(desiredLane == 3) desiredLane = 2;
            anim.SetBool("right",true);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if(desiredLane == -1) desiredLane = 0;
            anim.SetBool("left",true);
        }
        Vector3 targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(desiredLane == 0)
        {
            targetPos += Vector3.left * laneDistance;
        }else if(desiredLane == 2)
        {
            targetPos += Vector3.right * laneDistance;
        }
        Vector3 direction = targetPos - transform.position;
        if(transform.position == targetPos) return;
        transform.position += direction*Time.deltaTime*speedMove/2;
    }

    private void Jump()
    {
        rb.velocity += new Vector3(0,jumpForce,0);
        isJump = true;
        anim.SetBool("IsJump", true);
    }

    private void FixedUpdate() {
        transform.position += Vector3.forward * speedMove * Time.deltaTime;
    }
    private IEnumerator Slide()
    {
        playerCollider.height = 0.5f;
        yield return new WaitForSeconds(0.5f);
        playerCollider.height = 2.5f;
    }
}
