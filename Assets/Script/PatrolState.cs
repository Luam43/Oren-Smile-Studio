using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour
{
    private Rigidbody2D rb;

    public float KecepatanGerak;

    public bool kekanan;

    public Transform DeteksiTanah;
    public float jarakRaycast;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        kekanan = true;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(KecepatanGerak, rb.velocity.y);

        RaycastHit2D infotanah = Physics2D.Raycast(DeteksiTanah.position, Vector2.down, jarakRaycast);
        if(infotanah.collider == false)
        {
            if(kekanan == true)
            {
                KecepatanGerak *= -1f;
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                kekanan = false;
            }
            else
            {
                KecepatanGerak *= -1f;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                kekanan = true;
            }
        }
        
    }
}
