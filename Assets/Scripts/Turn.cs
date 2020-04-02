using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    enum Player {P1, P2};


    // Start is called before the first frame update
    void Start()
    {
        Player playerTurn;

        playerTurn = Player.P1; //P1 always goes first

    }

}
