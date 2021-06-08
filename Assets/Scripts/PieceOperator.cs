using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PieceOperator : MonoBehaviour
{
    public GameObject XPiece;
    public GameObject OPiece;
    public Turn currentTurn;
    public Button button;
    public int spaceNumber;

    public void PlacePiece() // OnClick() for each button when its clicked
    {

        if(button.interactable = true){
            button.interactable = false; // disables buttons from being clicked

            switch(currentTurn.currentState)
            { 
            case PlayerPiece.O: // X Turn
                print("O's Turn");
                GM.Instance.oArray.Add(spaceNumber); // Add indicated spaceNumber to oArray
                OPiece.SetActive(true);
                GM.Instance.audioManager.Play("OPlay");
                break;

            case PlayerPiece.X:
                print("X's Turn");
                GM.Instance.xArray.Add(spaceNumber); // Add indicated spaceNumber to XArray
                XPiece.SetActive(true);
                GM.Instance.audioManager.Play("XPlay");
                break;
            }

            print("currentTurn.currentState: " + currentTurn.currentState);
            GM.Instance.CheckWinConditions();  
            currentTurn.NextTurn();
        } 
    }

    // public void ResetPieces()
    // {
    //     XPiece.SetActive(false);
    //     OPiece.SetActive(false);
    //     // SpotTaken = false; // Implement SpotTaken to ResetGame Script 
    // }
       
    }
