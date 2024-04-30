using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak : MonoBehaviour
{
    Rigidbody2D Rb;
    public float ms;
    public float Jf;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horiz = Input.GetAxisRaw("Horizontal"); //a,d, kiri kanan
        Rb.velocity = new Vector2(ms * horiz, Rb.velocity.y);
        if(Input.GetButtonDown("Jump")) //space
        {
            Rb.AddForce(new Vector2(0, Jf));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //statement
        Destroy(gameObject);
    }

}
