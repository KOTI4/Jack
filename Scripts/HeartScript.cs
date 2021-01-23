using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public JackBehaviour jack;

    private void OnColliderEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this);
            jack.setHp(jack.getHp() + 1);
        }
    }

}
