using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomScript : MonoBehaviour
{
    public bool isGrounded;
    public bool isOnTrampoline;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flat")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Trampoline")
        {
            isOnTrampoline = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flat")
        {
            isGrounded = false;
        }
        if (collision.gameObject.tag == "Trampoline")
        {
            isOnTrampoline = false;
        }
    }
}
