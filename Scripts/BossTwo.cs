using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwo : MonoBehaviour
{

    public GameObject Player;
    public GameObject Fireball;
    private float speedVer;
    private float speed;
    private int timeToAttack;
    // Start is called before the first frame update
    void Start()
    {
        timeToAttack = 100;
        speedVer = 0.05f;
        speed = speedVer;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - Player.transform.position.x < 6.5)
            transform.position = new Vector3(transform.position.x + 0.1f,
                                             transform.position.y,
                                             transform.position.z);
        if (transform.position.x - Player.transform.position.x < 6)
            transform.position = new Vector3(transform.position.x + 0.05f,
                                             transform.position.y,
                                             transform.position.z);
        if (transform.position.x - Player.transform.position.x > 6.5)
            transform.position = new Vector3(transform.position.x - 0.05f,
                                             transform.position.y,
                                             transform.position.z);
        if (transform.position.x - Player.transform.position.x > 5)
            transform.position = new Vector3(transform.position.x - 0.1f,
                                             transform.position.y,
                                             transform.position.z);


        
        if (transform.position.y - Player.transform.position.y < 1) speed = speedVer;
        if (transform.position.y - Player.transform.position.y > 3) speed = -speedVer;
        transform.position = new Vector3(transform.position.x,
                                         transform.position.y + speed,
                                         transform.position.z);

        timeToAttack--;
        if (timeToAttack == 0)
        {
            Attack();
        }
    }


    public void Attack()
    {

    }
}
