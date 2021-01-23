using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    private int currentLevel;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name[3]; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        if (currentLevel != 8)
            currentLevel += 1;
        SceneManager.LoadScene("lvl" + currentLevel.ToString());
    }
}
