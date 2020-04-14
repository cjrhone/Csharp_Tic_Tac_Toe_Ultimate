using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public PlayerPiece currentState;

    public PlayerPiece NextTurn()
    {
        currentState = (PlayerPiece)(((int)currentState + 1 ) % 3);

        Debug.Log("current state: " + currentState);

        return currentState;
    }

}
