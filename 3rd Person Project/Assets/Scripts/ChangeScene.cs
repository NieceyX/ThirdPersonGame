using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   


    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.E))
        {
            Application.LoadLevel("Scene2");
        }
        */
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void MainScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
