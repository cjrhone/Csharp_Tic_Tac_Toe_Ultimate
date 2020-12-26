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

            // buttonText.text = currentTurn.currentState.ToString(); // REPLACES blank "" text with X/O 

            currentTurn.NextTurn();

            button.interactable = false; // disables buttons from being clicked

            if(currentTurn.currentState == PlayerPiece.X) // X Turn.. I Don't understand how this code works 
            {
                print("X's Turn");
                print("currentTurn.currentState: " + currentTurn.currentState);
                GM.Instance.oArray.Add(spaceNumber); // Add indicated spaceNumber to oArray
                OPiece.SetActive(true);

                FindObjectOfType<AudioManager>().Play("XPlay");

                GM.Instance.CheckWinConditions();

            }

            else // O Turn
            {
                print("O's Turn");
                print("currentTurn.currentState: " + currentTurn.currentState);
                GM.Instance.xArray.Add(spaceNumber); // Add indicated spaceNumber to XArray
                XPiece.SetActive(true);

                FindObjectOfType<AudioManager>().Play("OPlay");

                GM.Instance.CheckWinConditions();    

            };
    }

    public void TestFunction()
    {
        Debug.Log("TEST FUNCTION WORKING!");
    }

    public void ResetPieces()
    {
        XPiece.SetActive(false);
        OPiece.SetActive(false);
    }
       
    }
