using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_Play2 : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public int walkSpeed;
    public float jumpSpeed;
    private float moveInputH;
    public bool grounded;
    public Animator animator;
    public bool player1or2;

    public  bool enablePlayer = true;
    private bool upORdown = false;

    public string inputMove;
    public KeyCode inputDown;
    public KeyCode inputJump;
    public KeyCode inputShoot;
    public KeyCode inputPunch;
    public KeyCode inputKick;
    //public KeyCode inputBlock;

    public status2 status;
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {   
        if (player1or2 == false && enablePlayer == true) {
            moveInputH = Input.GetAxisRaw(inputMove);
            rigidbody.velocity = new Vector2(moveInputH * walkSpeed, rigidbody.velocity.y);
            if (moveInputH == 0)
            {
                animator.SetBool("walk", false);
            }
            else
            {
                animator.SetBool("walk", true);

            }
            if (moveInputH > 0) //เดินขวา
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                // print("D");
            }
            else if (moveInputH < 0) //เดินซ้าย
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                //print("A");
            }
        }

        if (player1or2 == true && enablePlayer == true)
        {
            moveInputH = Input.GetAxisRaw(inputMove);
            rigidbody.velocity = new Vector2(moveInputH * walkSpeed, rigidbody.velocity.y);
            if (moveInputH == 0)
            {
                animator.SetBool("walk", false);
            }
            else
            {
                animator.SetBool("walk", true);

            }
            if (moveInputH > 0) //เดินขวา
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                // print("D");
            }
            else if (moveInputH < 0) //เดินซ้าย
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                //print("A");
            }
        }


        if (Input.GetKeyDown(inputJump) && grounded == true) //กระโดด
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
            animator.SetTrigger("jump");
           // print("Jump");
        }

        if (upORdown == false) {
            if (Input.GetKeyDown(inputKick))
            { // เตะ
                animator.SetTrigger("kick");
                //print("K");
            }

            if (Input.GetKeyDown(inputPunch)) //ต่อย
            {
                animator.SetTrigger("attack1");
            }

           /* if (Input.GetKey(inputBlock)) // บล็อก
            {
                animator.SetBool("block", true);
                rigidbody.velocity = new Vector2(0 * walkSpeed, rigidbody.velocity.y);
                //print("W");
            }*/
            else
            {
                animator.SetBool("block", false);
            }
        }

        if (Input.GetKey(inputDown) && grounded == true)
        {
            animator.SetBool("down", true);
            rigidbody.velocity = new Vector2(0 * walkSpeed, rigidbody.velocity.y);
            upORdown = true;
            //print("S");
            if (upORdown == true) {
                if (Input.GetKeyDown(inputKick))
                { // โจมตี
                    animator.SetTrigger("down_kick");
                    //print("K");
                }

                /*if (Input.GetKey(inputBlock))
                {
                    animator.SetBool("down_block", true);
                    //print("W");
                }
                else
                {
                    animator.SetBool("down_block", false);
                }*/
            }          
        }
        else
        {
            animator.SetBool("down", false);
            upORdown = false;
        }

    }

}
