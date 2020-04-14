using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    enum PlayerPiece 
    {
        UNSET, X, O
    }

    private PlayerPiece currentState;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    public void NextTurn()
    {
        currentState = (PlayerPiece)(((int)currentState + 1 ) % 3);

        Debug.Log("current state: " + currentState);


        // NextTurn will cycle the turn, incrementing up or resetting to P1 
    }

}
