using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
////////////////
// This Awake() Function creates a singleton of GM 
// NO TOUCHY! NO!
    public static GM Instance { get; private set; }
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
////////////////

    public int counter = 0;

    PlayerPiece XorO;

    public Button[] gridSpaces;

    private int[][] WinningNumbers = new int[8][];

    public List<int> xArray = new List<int>();
    public List<int> oArray = new List<int>();

    public Text spaceText;
    public Text winText;
    
    public PieceOperator piecesomethingorother;

    void Start()
    {

        WinningNumbers[0] = new int[] {0,1,2};
        WinningNumbers[1] = new int[] {3,4,5};
        WinningNumbers[2] = new int[] {6,7,8};

        WinningNumbers[3] = new int[] {0,3,6};
        WinningNumbers[4] = new int[] {1,4,7};
        WinningNumbers[5] = new int[] {2,5,8};

        WinningNumbers[6] = new int[] {0,4,8};
        WinningNumbers[7] = new int[] {2,4,6};

        // {0,1,2}, {3,4,5}, {6,7,8},   // horizontal wins
        // {0,3,6}, {1,4,7}, {2,5,8},   // vertical wins
        // {0,4,8}, {2,4,6}             // diagonal wins

    }

    public void GameWin()
    {
        foreach(Button space in gridSpaces)
        {
            //Indicate who won 
            space.interactable = false;
            counter = 0;
        }

          winText.GetComponent<Text>().enabled = true;
    }

    public void CheckWinConditions()
    {
        counter += 1;

        foreach(Button space in gridSpaces)
            {
                // spaceText = space.GetComponentInChildren<Text>();

                foreach(int[] win in WinningNumbers)
                {

                    foreach(int number in win)
                    {
                        if(xArray.Contains(win[0]) && xArray.Contains(win[1]) && xArray.Contains(win[2]))
                        {
                            print("X Player -- Well Done.");
                            GameWin();
                        }

                        if(oArray.Contains(win[0]) && oArray.Contains(win[1]) && oArray.Contains(win[2]))
                        {
                            print("O Player -- Well Done.");
                            GameWin();
                        }
                     
                    }
               
                }

    }



        if(counter == 9) // && Condition of no winner 
        {
            Debug.Log("TIE GAME!!");

        }

    }

}
