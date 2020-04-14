using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public GameObject Xpiece;
    public GameObject Opiece;

    PlayerPiece XorO;

    public GameObject[] Squares;
    
    public PieceOperator piecesomethingorother;

    // Start is called before the first frame update
    void Start()
    {
        // print(Squares[0]);
        // print(Squares[1]);

        piecesomethingorother.TestFunction(); // just grabs the script, because that's all we're calling 

    }

    void CheckWinConditions()
    {
        if(Squares[0].activeSelf &&
           Squares[1].activeSelf &&
           Squares[2].activeSelf)
        {
            Debug.Log("BINGO!");
        }
    }

    // void Update()
    // {
        
    // }

}
