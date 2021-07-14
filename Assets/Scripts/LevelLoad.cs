using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public bool vsCPU;


    public void PlayGameVsPlayer() // Gameboard against player 
    {
        FindObjectOfType<AudioManager>().Play(Sound.SoundType.Select);
        FindObjectOfType<AudioManager>().StopPlaying(Sound.SoundType.Menu);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); // passing levelIndex to LoadLevel through GetActiveScene() 
        FindObjectOfType<AudioManager>().Play(Sound.SoundType.Ready_VO);

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Time.timeScale = 0;
        Application.Quit();
    }

    public void PlayGameVsCPU() // Gameboard against CPU
    {
        Debug.Log("Clicked PlayerVSCPU");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        vsCPU = true;
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
