using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpScript : MonoBehaviour
{
    public JackBehaviour jackBehaviour;
    public GameObject heart;
    private List<GameObject> hearts;
    // Start is called before the first frame update
    void Start()
    {
        hearts = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jackBehaviour.getHp() > hearts.Count)
        {
            var newHeart = GenerateInstance(heart, new Vector3(transform.position.x + 0.65f*hearts.Count,
                                                               transform.position.y, 5));
            newHeart.transform.parent = transform;
            hearts.Add(newHeart);
        }
        if (jackBehaviour.getHp() < hearts.Count)
        {
            Destroy(hearts[hearts.Count-1]);
            hearts.RemoveRange(hearts.Count - 1, 1);
        }
    }

    public GameObject GenerateInstance(GameObject gameObject, Vector3 position)
    {
        var temp = Instantiate(gameObject);
        temp.transform.position = position;
        return temp;
    }
}
