using System;
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
    public spinthatbitch spinX;
    public spinthatbitch spinO;

    public static bool cpuChallenger;

    public bool SpotTaken;

    public bool cpuTurn;

    public void PlacePiece() // OnClick() for each button when its clicked
    {
        var playerWinCheck = GM.Instance.playerWin;

        if(button.interactable == true){
            button.interactable = false; // disables buttons from being clicked
            SpotTaken = true;

            switch(currentTurn.currentState)
            { 
            case PlayerPiece.O: // X Turn
                print("O Piece Placed");
                GM.Instance.oArray.Add(spaceNumber); // Add indicated spaceNumber to oArray
                OPiece.SetActive(true);
                FindObjectOfType<AudioManager>().Play(Sound.SoundType.oMove);

                break;

            case PlayerPiece.X:
                print("X Piece Placed");
                GM.Instance.xArray.Add(spaceNumber); // Add indicated spaceNumber to XArray
                XPiece.SetActive(true);
                FindObjectOfType<AudioManager>().Play(Sound.SoundType.xMove);
                break;
            }

            GM.Instance.CheckWinConditions();  
            currentTurn.NextTurn();

            if(GM.Instance.cpuChallenger && !playerWinCheck)
            {
                Debug.Log("CPU Challenger Recognized");
                cpuTurn = true;

                if(GM.Instance.gridSpaces.Length > 1 ){

                    var notTakenSpaces = Array.FindAll<PieceOperator>(GM.Instance.gridSpaces, gridSpace => gridSpace.SpotTaken == false );
                    //Randomize 
                    var count = notTakenSpaces.Length;
                    //TODO: Check if there are any spots left, (Length > 0 && != null) if there aren't, exit from this if statement at least
                    // And Logic to check if player has won already 
                    var spotToTake = UnityEngine.Random.Range(0, count - 1);

                    Debug.Log("CPU has Chosen: " + notTakenSpaces[spotToTake]);
                    notTakenSpaces[spotToTake].CheckCPUTurn();
                    
                }

            }    
            
        } 
    }

    public void CheckCPUTurn()
    {
        if(GM.Instance.cpuChallenger)
        {
            Debug.Log("CHECKING CPUTURN...");
            if(button.interactable == true){
            button.interactable = false; // disables buttons from being clicked
            SpotTaken = true;

            switch(currentTurn.currentState)
            { 
            case PlayerPiece.O: // X Turn
                print("O Piece Placed (CPU)");
                GM.Instance.oArray.Add(spaceNumber); // Add indicated spaceNumber to oArray
                OPiece.SetActive(true);
                FindObjectOfType<AudioManager>().Play(Sound.SoundType.oMove);
                break;

            case PlayerPiece.X:
                print("X Piece Placed (CPU)");
                GM.Instance.xArray.Add(spaceNumber); // Add indicated spaceNumber to XArray
                XPiece.SetActive(true);
                FindObjectOfType<AudioManager>().Play(Sound.SoundType.xMove);
                break;
            }

            // print("currentTurn.currentState: " + currentTurn.currentState);
            cpuTurn = false;
            GM.Instance.CheckWinConditions();  
            currentTurn.NextTurn();
            }
        }
    }

    public void ResetPiece()
    {
        print($"Resetting X Piece: {XPiece}");
        XPiece.SetActive(false);
        print($"Resetting O Piece: {OPiece}");
        OPiece.SetActive(false);
        SpotTaken = false;
        button.interactable = true;
    }
       
}
