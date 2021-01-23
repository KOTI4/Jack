using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainScript : MonoBehaviour
{
    public int number;
    public bool isActivated;
    public GameObject chainPart;
    private List<GameObject> chainParts;
    // Start is called before the first frame update
    void Start()
    {
        chainParts = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            BuildChain();
            isActivated = false;
        }
    }

    void BuildChain()
    {
        for(int i = 0; i < number; i++)
        {
            var newPart = GenerateInstance(chainPart, new Vector3(transform.position.x ,
                                                               transform.position.y + 1f * chainParts.Count,
                                                               transform.position.z));
            chainParts.Add(newPart);
        }
    }

    public GameObject GenerateInstance(GameObject gameObject, Vector3 position)
    {
        var temp = Instantiate(gameObject);
        temp.transform.position = position;
        return temp;
    }
}
