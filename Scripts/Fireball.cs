using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speedVer = 0.16f;
    public float speedHor = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if((int)transform.position.x == (int)endPosition.x &&
           (int)transform.position.y == (int)endPosition.y)
        {
            Destroy(this);
        }
            
        else {
            if ((int)transform.position.x == (int)endPosition.x)
                transform.position = new Vector3(transform.position.x + speedHor,
                                                 transform.position.y,
                                                 transform.position.z);
            else
                transform.position = new Vector3(transform.position.x - speedHor,
                                                 transform.position.y,
                                                 transform.position.z);
            if ((int)transform.position.y == (int)endPosition.y)
                transform.position = new Vector3(transform.position.x,
                                                 transform.position.y + speedVer,
                                                 transform.position.z);
            else
                transform.position = new Vector3(transform.position.x,
                                                 transform.position.y - speedVer,
                                                 transform.position.z);
        }
        
    }
}
