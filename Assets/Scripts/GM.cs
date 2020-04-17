using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM Instance { get; private set; }

// This Awake() Function creates a singleton of GM 
// NO TOUCHY! NO!
    private void Awake() 
    {
        if (Instance == null) // if theres nothing stored within Instance
        {
            Instance = this; // Analogy: Setting to cookie cutter, rather than cookie 
            DontDestroyOnLoad(gameObject); // prevents deletion of GM on Awake ( works with else statement )
        }
        else 
        {
            Destroy(gameObject); // prevents duplicating our Instance of GM
        }
    }
// SINGLETON SCRIPT END
// Please proceed to play around with code ya goof


    public int counter = 0;

    PlayerPiece XorO;

    public GameObject[] Squares;
    
    public PieceOperator piecesomethingorother;

    // Start is called before the first frame update
    // void Start()
    // {
    //     // print(Squares[0]);
    //     // print(Squares[1]);

    //     piecesomethingorother.TestFunction(); // Test script - just grabs the script, because that's all we're calling 

    // }

    void CheckWinConditions()
    {
        counter += 1;

        Debug.Log("Counter: " + counter);
        
        Debug.Log("Checking Win");

        if(counter == 9)
        {
            Debug.Log("TIE GAME!!");
        }

    }

    // void Update()
    // {
        
    // }

}
