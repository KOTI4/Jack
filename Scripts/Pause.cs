using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Canvas playCanvas;
    public Canvas pauseCanvas;
    public Canvas deadCanvas;
    public Canvas learnCanvas;
    public JackBehaviour jack;

    public bool gameIsPaused;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
        pauseCanvas.enabled = false;
        deadCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q)) switchGamePaused();
        if (jack.getHp() == 0)
        {
            Time.timeScale = 0;
            playCanvas.enabled = false;
            deadCanvas.enabled = true;

        }
    }

    public void switchGamePaused()
    {
        if (gameIsPaused)
        {
            gameIsPaused = false;
            Time.timeScale = 1;
            playCanvas.enabled = true;
            pauseCanvas.enabled = false;
        }
        else
        {
            gameIsPaused = true;
            Time.timeScale = 0;
            playCanvas.enabled = false;
            pauseCanvas.enabled = true;
        }
    }


    public void switchGameLearn()
    {
        if (gameIsPaused)
        {
            gameIsPaused = false;
            Time.timeScale = 1;
            playCanvas.enabled = true;
            learnCanvas.enabled = false;
        }
        else
        {
            gameIsPaused = true;
            Time.timeScale = 0;
            playCanvas.enabled = false;
            learnCanvas.enabled = true;
        }
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("menu");
        gameIsPaused = false;
        Time.timeScale = 1;

    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameIsPaused = false;
        Time.timeScale = 1;

    }
}
