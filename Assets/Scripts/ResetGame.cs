using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    // We need a SCRAPER -- something that will COLLECT the value of placed pieces -- check with the WIN CONDITIONS -- and allow us to reset values
    // Reset PlayerPiece to "" -- this may involve setting up enum to start with ""
    // enable all buttons to be interactable 

    public GameObject transitionScreen;
    public Button[] buttons;
    public Text newText;
    public Turn currentTurn;
    public Text winText;
    public GameObject[] ResetPieces;

    public GameObject resetButton;

    public void Reset()
    {
        if(resetButton.activeSelf == true) // IF RESET BUTTON VISIBLE -- HIDE IT!
        {
            resetButton.SetActive(false);
        }

        FindObjectOfType<AudioManager>().Play("Reset");

        foreach(var gridSpace in GM.Instance.gridSpaces){
            gridSpace.spinO.ResetAnimation();
            gridSpace.spinX.ResetAnimation();
        }

        foreach (Button button in buttons)
        {
            button.interactable = true; // SHOULD enable each button but isn't
            newText = button.GetComponentInChildren<Text>(); //grabs text child in each button
            newText.text = ""; // resets to blank value

            GameObject xpiece = GameObject.Find("xpiece");
            GameObject opiece = GameObject.Find("opiece");

            if(xpiece)
            {
                xpiece.SetActive(false);
                print("Resetting X Piece: " + xpiece);
                
            }

            if(opiece)
            {
                opiece.SetActive(false);
                print("Resetting O Piece: " + opiece);
            }

            

        GM.Instance.turnManager.Reset(GM.Instance.firstPlayer); //resets counter to 0 if reset button called
        GM.Instance.playerWin = false; // resets playerWin trigger -- used to indicate tie or win
        }

       

        // Reset Array Pieces
        // winText.enabled = false;
        GM.Instance.xArray = new List<int>(); // Reset xArray
        GM.Instance.oArray = new List<int>(); // Reset oArray

        currentTurn.currentState = 0; // Begin with X turn
    }

    public void ReplayButton()
    {
        transitionScreen.SetActive(false);
        winText.gameObject.SetActive(false);
        Reset();
        GM.Instance.xHealthBar.Initialize(GM.maxHealth); // Reset healthbar to default ( on-screen visual )
        GM.Instance.oHealthBar.Initialize(GM.maxHealth);

    }

    
}
