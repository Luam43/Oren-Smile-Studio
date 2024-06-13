using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    public float jumpTime = 0.35f;
    public float jumpTimeCounter;
    private bool isJumping;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;
    public Animator anim;


    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("horizontal", Mathf.Abs(input));
        if(input < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (input > 0)
        {
            spriteRenderer.flipX = false;
        }

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);
        anim.SetBool("isJumping", !isGrounded);

        anim.SetFloat("verticalSpeed", playerRb.velocity.y);


        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerRb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetButton("Jump") && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                playerRb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }

            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        { 
            isJumping = false;
        }
    }
    
    void FixedUpdate()
    {
        if(KBCounter <= 0)
        {
            playerRb.velocity = new Vector2 (input * speed, playerRb.velocity.y);
        }
        else
        {
            if(KnockFromRight == true)
            {
                playerRb.velocity = new Vector2(-KBForce, KBForce);
            }
            if(KnockFromRight == false)
            {
                playerRb.velocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }
    }
}
