using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public JackBehaviour jack;

    private void OnColliderEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this);
            jack.setCoins(jack.getCoins() + 1);
        }
    }
}
