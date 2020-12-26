using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public PlayerPiece currentState;
    public int turnNumber = 1;

    public void Reset(PlayerPiece firstPlayer) {
        turnNumber = 1;
        currentState = firstPlayer;
    }

    public PlayerPiece NextTurn()
    {
        turnNumber++;
        currentState = (PlayerPiece)(((int)currentState + 1 ) % (int)PlayerPiece.PLAYER_PIECE_COUNT); //Modulo number depends on number of choices. 2 because X or O

        // Debug.Log("current state: " + currentState);

        return currentState;
    }
}
