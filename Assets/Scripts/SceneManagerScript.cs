using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    public Text ValueText;

    private void Start()
    {
        ValueText.text =  GM.Instance.counter.ToString(); // Instance calls on a global static Instance of GM
    }

    public void GoToFirstScene()
    {
        GM.Instance.counter++;
        Debug.Log(GM.Instance.counter);
        SceneManager.LoadScene("first");

    }

    public void GoToSecondScene()
    {
        GM.Instance.counter++;
        Debug.Log(GM.Instance.counter);
        SceneManager.LoadScene("second");
    }

}
