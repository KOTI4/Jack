using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springboard : MonoBehaviour
{
    public Animator animator;
    public bool IsJackOn;
    private int TimeIsJackOn;
    // Start is called before the first frame update
    void Start()
    {
        IsJackOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeIsJackOn > 0) TimeIsJackOn--;
        if (TimeIsJackOn > 0) animator.SetBool("IsJackOn", true);
        if (TimeIsJackOn <= 0) animator.SetBool("IsJackOn", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TimeIsJackOn = 18;
        }
        
    }

}
