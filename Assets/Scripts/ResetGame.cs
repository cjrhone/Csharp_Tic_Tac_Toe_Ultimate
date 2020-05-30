using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    // We need a SCRAPER -- something that will COLLECT the value of placed pieces -- check with the WIN CONDITIONS -- and allow us to reset values
    // Reset PlayerPiece to "" -- this may involve setting up enum to start with ""
    // enable all buttons to be interactable 

    public PieceOperator placedPieces;
    public Button[] buttons;
    public Text newText;
    public Turn currentTurn;
    public Text winText;
    public GameObject[] ResetPieces;

    public void Reset()
    {
        FindObjectOfType<AudioManager>().Play("Reset");

        foreach (Button button in buttons)
        {
            button.interactable = true; // enables each button
            newText = button.GetComponentInChildren<Text>(); //grabs text child in each button
            newText.text = ""; // resets to blank value

            GameObject xpiece = GameObject.Find("xpiece");
            GameObject opiece = GameObject.Find("opiece");

            if(xpiece)
            {
                xpiece.SetActive(false);
            }

            if(opiece)
            {
                opiece.SetActive(false);
            }

            

        GM.Instance.counter = 0; //resets counter to 0 if reset button called
        GM.Instance.playerWin = false; // resets playerWin trigger -- used to indicate tie or win

        }

       

        // Reset Array Pieces
        winText.enabled = false;
        GM.Instance.xArray = new List<int>();
        GM.Instance.oArray = new List<int>();

        currentTurn.currentState = 0;


        // placedPieces.button.interactable = true;
    }

    
}
