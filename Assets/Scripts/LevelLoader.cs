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
        FindObjectOfType<AudioManager>().Play(Sound.SoundType.Select);
        FindObjectOfType<AudioManager>().StopPlaying(Sound.SoundType.Menu);

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); // passing levelIndex to LoadLevel through GetActiveScene()

        FindObjectOfType<AudioManager>().Play(Sound.SoundType.Ready_VO);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play(Sound.SoundType.Select);
        FindObjectOfType<AudioManager>().StopPlaying(Sound.SoundType.Menu);

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
    
    // IEnumerator GameStart()
    // {
    //     yield return new WaitForSeconds(3f);
    //     Time.timeScale = 0;
    //     FindObjectOfType<AudioManager>().Play("battle");
    //     FindObjectOfType<AudioManager>().Play("ready");
    //     yield return new WaitForSeconds(3f);
    //     Time.timeScale = 1;
    //     Debug.Log("GameStart has finished");

    // }
}
