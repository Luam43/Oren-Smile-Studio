using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    BoxCollider2D collider2d;


    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //If player y is below a platform y turn off collider
        if (Player.transform.position.y < transform.position.y)
        {
            collider2d.enabled = false;
        }

        //If player y is above a platform y turn on collider
        if (Player.transform.position.y > transform.position.y)
        {
            collider2d.enabled = true;
        }

        //if user pushes down then turn off collider
        if(Input.GetAxis("Vertical") < 0)
        {
            collider2d.enabled = false;
        }

    }
}
