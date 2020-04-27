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

    public int xWins = 0;

    public int oWins = 0;

    PlayerPiece XorO;

    public Button[] gridSpaces;

    private int[][] WinningNumbers = new int[8][];

    public List<int> xArray = new List<int>();
    public List<int> oArray = new List<int>();

    public AudioClip audiodata;

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

        audiodata = GetComponent<AudioClip>();

        // {0,1,2}, {3,4,5}, {6,7,8},   // horizontal wins
        // {0,3,6}, {1,4,7}, {2,5,8},   // vertical wins
        // {0,4,8}, {2,4,6}             // diagonal wins

    }

    public void GameWin(int[] winningSpots)
    {

        // WIN TYPE CASES
        
        /////////////////
        /////////////////
        if(winningSpots == WinningNumbers[0])
        {
            Debug.Log("{0,1,2}");
        }

        else if(winningSpots == WinningNumbers[1])
        {
            Debug.Log("{3,4,5}");
        }
        else if(winningSpots == WinningNumbers[2])
        {
            Debug.Log("{6,7,8}");
        }
        else if(winningSpots == WinningNumbers[3])
        {
            Debug.Log("{0,3,6}");
        }
        else if(winningSpots == WinningNumbers[4])
        {
            Debug.Log("{1,4,7}");
        }
        else if(winningSpots == WinningNumbers[5])
        {
            Debug.Log("{2,5,8}");
        }
        else if(winningSpots == WinningNumbers[6])
        {
            Debug.Log("{0,4,8}");
        }

          else if(winningSpots == WinningNumbers[7])
        {
            Debug.Log("{2,4,6}");
        }
        /////////////////
        /////////////////

        //END CASES

        foreach(Button space in gridSpaces)
        {
            //Indicate who won 
            space.interactable = false;
            counter = 0;
        }

          winText.GetComponent<Text>().enabled = true; //enables Win Text on GameWin
    }

    public void CheckWinConditions()
    {
        counter += 1;

        // We want to
        // 1 - Indicate TYPE of win ( WinningNumbers[0-7] )
        // 2 - Indicate WHO won ONCE
        // 3 - Incriment and display win count for X or O player

        foreach(Button space in gridSpaces)
            {

                foreach(int[] win in WinningNumbers)
                {
                        if(xArray.Contains(win[0]) && xArray.Contains(win[1]) && xArray.Contains(win[2]))
                        {
                            print("X Player -- Well Done.");
                            xWins++;
                            GameWin(win);
                            return;
                        }

                        if(oArray.Contains(win[0]) && oArray.Contains(win[1]) && oArray.Contains(win[2]))
                        {
                            print("O Player -- Well Done.");
                            oWins++;
                            GameWin(win);
                            return;
                        }
               
                }

    }

        if(counter == 9) // && Condition of no winner 
        {
            Debug.Log("TIE GAME!!");

        }

    }

}
