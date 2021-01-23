using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void LevelButton()
    {
        SceneManager.LoadScene("levels");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
