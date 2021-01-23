
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaScript : MonoBehaviour
{
    public JackBehaviour jackBehaviour;
    public GameObject stamina;
    private List<GameObject> staminas;
    // Start is called before the first frame update
    void Start()
    {
        staminas = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jackBehaviour.getStamina()/100 > staminas.Count)
        {
            var newStamina = GenerateInstance(stamina, new Vector3(transform.position.x + 0.2f * staminas.Count,
                                                               transform.position.y,  0 - staminas.Count));
            newStamina.transform.parent = transform;
            staminas.Add(newStamina);
        }
        if (jackBehaviour.getStamina()/100 < staminas.Count)
        {
            Destroy(staminas[staminas.Count - 1]);
            staminas.RemoveRange(staminas.Count - 1, 1);
        }
    }

    public GameObject GenerateInstance(GameObject gameObject, Vector3 position)
    {
        var temp = Instantiate(gameObject);
        temp.transform.position = position;
        return temp;
    }
}
