using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //this moves the game to the next scene/level when the corresponding button is pressed
    }
    public void QuitGame()
    {
        UnityEngine.Application.Quit();
        //this quits the game
    }
}
