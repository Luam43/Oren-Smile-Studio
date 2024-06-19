using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] 
    private Animator anim;
    private bool openedAllowed;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (openedAllowed && Input.GetKeyDown(KeyCode.F))
            IsOpened();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            openedAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            openedAllowed = false;
        }
    }

    private void IsOpened()
    {
        if (openedAllowed == true)
            anim.SetBool("isOpened", true);
        else
            anim.SetBool("isOpened", false);
    }
}
