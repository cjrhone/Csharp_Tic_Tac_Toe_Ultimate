using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void PlayGameVsPlayer() // Gameboard against player 
    {
        FindObjectOfType<AudioManager>().Play("select");
        FindObjectOfType<AudioManager>().StopPlaying("menu");

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); // passing levelIndex to LoadLevel through GetActiveScene()

        FindObjectOfType<AudioManager>().Play("battle");



    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("select");
        FindObjectOfType<AudioManager>().StopPlaying("menu");

        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayGameVsCPU() // Gameboard against CPU
    {
        Debug.Log("Player VS CPU");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // goes scene index 2 ( CPU Gameboard ) 
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start"); // "Start" is the Parameter we named and set in animation controller 

        //Wait
        yield return new WaitForSeconds(transitionTime); // pauses corountine for x seconds 

        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
