using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    public PlayerPiece currentState;
    public int turnNumber = 1;
    public GameObject xTurn;
    public GameObject oTurn;

    public void Start()
    {
        currentState = PlayerPiece.X;
    }

    public void Reset(PlayerPiece firstPlayer) {
        turnNumber = 1;
        xTurn.SetActive(true);
        oTurn.SetActive(false);
        currentState = firstPlayer;
    }

    // public void CheckCPU()
    // {
    //     // if(GM.Instance.cpuChallenger)
    //     // {
    //     //     GM.Instance.CPUTurn();
    //     //     cpuTurn = false;
    //     // }

    // }

    public PlayerPiece NextTurn()
    {
        if(currentState == PlayerPiece.O)
        {
            oTurn.SetActive(false);
            xTurn.SetActive(true);
        } 
        else {
            xTurn.SetActive(false);
            oTurn.SetActive(true);
        }
        // Debug.Log("currentState: " + currentState + "PlayerPiece: " + PlayerPiece.O);
        turnNumber++;
        currentState = (PlayerPiece)(((int)currentState + 1 ) % (int)PlayerPiece.PLAYER_PIECE_COUNT); //Modulo number depends on number of choices. 2 because X or O
        // cpuTurn = true;

        // Debug.Log("current state: " + currentState);

        // Reset(currentState);

        return currentState;
    }
}
