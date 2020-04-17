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


    public void Reset()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true; // enables each button
            newText = button.GetComponentInChildren<Text>(); //grabs text in each button
            newText.text = ""; // resets to blank value

            // Debug.Log(button);
            // newText = button.GetComponent<Text>();
            // newText.text = "";
        }

        // placedPieces.button.interactable = true;
    }

    
}
