using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossOne : MonoBehaviour
{

    public GameObject Player;
    public float speed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(System.Math.Abs(Player.transform.position.x - transform.position.x) -
           System.Math.Abs(Player.transform.position.y - transform.position.y) > 0)
        {
            if (Player.transform.position.x - transform.position.x > 0)
                transform.position = new Vector3(transform.position.x + speed,
                                                 transform.position.y,
                                                 transform.position.z);
            else
                transform.position = new Vector3(transform.position.x - speed,
                                                 transform.position.y,
                                                 transform.position.z);
        }
        else
        {
            if (Player.transform.position.y - transform.position.y > 0)
                transform.position = new Vector3(transform.position.x,
                                                 transform.position.y + speed,
                                                 transform.position.z);
            else
                transform.position = new Vector3(transform.position.x,
                                                 transform.position.y - speed,
                                                 transform.position.z);
        }


    }
}
