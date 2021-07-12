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

    public bool SpotTaken;

    public void PlacePiece() // OnClick() for each button when its clicked
    {

        if(button.interactable == true){
            button.interactable = false; // disables buttons from being clicked
            SpotTaken = true;

            switch(currentTurn.currentState)
            { 
            case PlayerPiece.O: // X Turn
                print("O's Turn");
                GM.Instance.oArray.Add(spaceNumber); // Add indicated spaceNumber to oArray
                OPiece.SetActive(true);
                FindObjectOfType<AudioManager>().Play(Sound.SoundType.oMove);

                break;

            case PlayerPiece.X:
                print("X's Turn");
                GM.Instance.xArray.Add(spaceNumber); // Add indicated spaceNumber to XArray
                XPiece.SetActive(true);
                FindObjectOfType<AudioManager>().Play(Sound.SoundType.xMove);
                break;
            }

            print("currentTurn.currentState: " + currentTurn.currentState);
            GM.Instance.CheckWinConditions();  
            currentTurn.NextTurn();
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
