using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameVsPlayer() // Gameboard against player 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // goes to next index scene ( 0 to 1 )

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayGameVsCPU() // Gameboard against CPU
    {
        Debug.Log("Player VS CPU");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // goes scene index 2 ( CPU Gameboard ) 
    }
}
