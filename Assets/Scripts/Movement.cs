using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    float hAxis;
    Vector2 direction;

    [SerializeField]
    float speed;
    [SerializeField]
    float jumpPower;
    [SerializeField]
    float scale;
    /*[SerializeField]
    InputActionReference attack;*/

    Rigidbody2D rb;

    [SerializeField]
    bool onGround = false;

    public Animator animator;
    public Player_Attack attack; //import Player_Attack.cs

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Facing();
        Animations();
        /*Player_Attack attack = new Player_Attack(); 
         * buat instance baru/import*/
        attack.Attack();
    }


    void Movement()
    {
        //Monitor horizontal keypresses and apply movement to player object
        hAxis = Input.GetAxis("Horizontal");
        direction = new Vector2(hAxis, 0);

        transform.Translate(direction * Time.deltaTime * speed);
    }

    void Jump()
    {
        //If spacebar pressed then apply velocity to yAxis
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            rb.velocity = new Vector2(0, jumpPower);
        }
    }

    void Facing()
    {
        //If player is moving left then scale = -1
        if (hAxis < 0)
        {
            transform.localScale = new Vector3(-scale, scale, 1);
        }

        //If player is moving right then scale = 1
        if (hAxis > 0)
        {
            transform.localScale = new Vector3(scale, scale, 1);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D capek)
    {
        //if the enter ground then allow jump
        if (capek.tag == "ground")
        {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D capek)
    {
        //if the exitsground then allow jump
        if (capek.tag == "ground")
        {
            onGround = false;
        }

        if (capek.tag == "enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

    void Animations()
    {
        animator.SetFloat("Moving", Mathf.Abs(hAxis));
        animator.SetBool("onGround", onGround);
    }
}
