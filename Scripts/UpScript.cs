using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpScript : MonoBehaviour
{
    public bool getUpWall;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flat")
        {
            getUpWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flat")
        {
            getUpWall = false;
        }
    }
}
