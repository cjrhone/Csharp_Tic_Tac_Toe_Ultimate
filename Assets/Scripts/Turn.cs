using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public PlayerPiece currentState;

    public PlayerPiece NextTurn()
    {
        currentState = (PlayerPiece)(((int)currentState + 1 ) % 2); //Modulo number depends on number of choices. 2 because X or O

        Debug.Log("current state: " + currentState);

        return currentState;
    }

}
