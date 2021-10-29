using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
////////////////
// This Awake() Function creates a SINGLETON of GM 
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

    public Turn turnManager;
    public PlayerPiece firstPlayer;

    public int xWins;
    public int oWins;
    public PieceOperator[] gridSpaces;

    // There are 8 possible ways to win Tic Tac Toe
    // The following are preset winning numbers, contained within an array called "WinningNumbers"
    // {0,1,2}, {3,4,5}, {6,7,8},   // horizontal wins
    // {0,3,6}, {1,4,7}, {2,5,8},   // vertical wins
    // {0,4,8}, {2,4,6}             // diagonal wins
    private int[][] WinningNumbers = {
        new int[] {0,1,2}, //[0]
        new int[] {3,4,5}, //[1]
        new int[] {6,7,8}, //[2]
        new int[] {0,3,6}, //[3]
        new int[] {1,4,7}, //[4]
        new int[] {2,5,8}, //[5]
        new int[] {0,4,8}, //[6]
        new int[] {2,4,6}, //[7]
    };

    public List<int> xArray = new List<int>();
    public List<int> oArray = new List<int>();

    //public Text spaceText;
    public GameObject transitionScreen;
    public Text winText;
    public Text xScore;
    public Text oScore;
    public bool playerWin = false;
    public Countdown resetTimer;
    public Text timerText;
    public ResetGame resetGame; // SCRIPT FOR ResetGame
    public HealthBar xHealthBar; // X HEALTH BAR REFERENCE
    public HealthBar oHealthBar; // O HEALTH BAR REFERENCE 
    public static int maxHealth = 25; // DEFAULT MAX HEALTH

    public LevelLoad isVsCPU;

    public bool cpuChallenger = true;

    
    void Start()
    {
        // Debug.Log("GM Start");
        // A GOOD PLACE FOR A COROUTINE
        // foreach(var space in gridSpaces)
        // {
        //     var cpuTurn = space.GetComponent<PieceOperator>();
        //     cpuTurn.PlacePiece();
        //     Debug.Log(space);
        // }

        // PieceOperator chosenSpace = chosenSpace.spaceNumber[0] 

        // CPU Challenger Logic 
        // if(gridSpaces.Length > 1 ){
        //     //Randomize 
        //     var count = gridSpaces.Length;
        //     var spotToTake = UnityEngine.Random.Range(0, count - 1);

        //     while(gridSpaces[spotToTake].SpotTaken == true) //checks if spot is taken
        //     {
        //         Debug.Log(gridSpaces[spotToTake] + " spot is taken");
        //         spotToTake = UnityEngine.Random.Range(0, count - 1);
        //     }
    
        //     gridSpaces[spotToTake].PlacePiece();
        //     Debug.Log("CPU has Chosen: " + gridSpaces[spotToTake]);
        // }

        // print("STARTING: maxHealth: " + maxHealth);

        xHealthBar.Initialize(maxHealth);
        oHealthBar.Initialize(maxHealth);

        xScore.text = "X Wins: " + xWins; 
        oScore.text = "O Wins: " + oWins;  
        turnManager.Reset(firstPlayer);
        //TODO: subscribe to resetTimer's "broadcasting" of time being up, so that we can choose a random move
        FindObjectOfType<AudioManager>().Play(Sound.SoundType.Battle);
    }

    //PLAYER WIN
    IEnumerator winTextCoroutine() //BUG goinng through winTextCoroutine Twice
    {
        Debug.Log("WinTextCoroutine");

         if( oHealthBar.playerHealth <= 0 ) // if O health = 0 ... X WINS!
        {
            Debug.Log("X WINS!");
            FindObjectOfType<AudioManager>().StopPlaying(Sound.SoundType.Battle);
            FindObjectOfType<AudioManager>().Play(Sound.SoundType.Victory);
            FindObjectOfType<AudioManager>().Play(Sound.SoundType.XWin_VO);


            transitionScreen.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            resetGame.gameObject.SetActive(true);
            StopCoroutine(winTextCoroutine()); // STOP Coroutine 
            yield return null;
        }

        else if( xHealthBar.playerHealth <= 0 ) // if X health = 0 ... O WINS!
        {
            Debug.Log("O WINS!");
            FindObjectOfType<AudioManager>().StopPlaying(Sound.SoundType.Battle);
            FindObjectOfType<AudioManager>().Play(Sound.SoundType.Victory);
            FindObjectOfType<AudioManager>().Play(Sound.SoundType.OWin_VO);

            transitionScreen.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            resetGame.gameObject.SetActive(true);
            StopCoroutine(winTextCoroutine()); // STOP Coroutine 
            yield return null;

        }

        else 
        {
            Debug.Log("3 Second TRANSITION...");
            transitionScreen.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            resetGame.Reset();
            transitionScreen.gameObject.SetActive(false);

        }
        // Debug.Log("PlayerWin: " + playerWin);
        yield return null;

    }

    public void GameWinEffect(int[] winningSpots)
    {
        foreach(int winningSpot in winningSpots){
            gridSpaces[winningSpot].spinX.PlayWinAnimation();
            gridSpaces[winningSpot].spinO.PlayWinAnimation();
        }

        // WIN TYPE CASES
        
        /////////////////
        /////////////////
        // ROWS - Horizontal | COLUMNS - Vertical
        if(winningSpots == WinningNumbers[0])
        {
            // Debug.Log("{0,1,2}"); // TOP Row win

            //ADD Horizontal | TOP Row | Animation
        }

        else if(winningSpots == WinningNumbers[1])
        {
            // Debug.Log("{3,4,5}");// MIDDLE Row win

             //ADD Horizontal | MIDDLE Row | Animation
             // ADD Scanner to find XPiece or OPiece
        }
        else if(winningSpots == WinningNumbers[2])
        {
            // Debug.Log("{6,7,8}"); // BOTTOM Row win

            //ADD Horizontal | BOTTOM Row | Animation
            // ADD Scanner to find XPiece or OPiece

        }
        else if(winningSpots == WinningNumbers[3])
        {
            // Debug.Log("{0,3,6}"); // LEFT Column win

            // ADD VERTICAL | LEFT Column | Animation
            // ADD Scanner to find XPiece or OPiece

        }
        else if(winningSpots == WinningNumbers[4])
        {
            // Debug.Log("{1,4,7}"); // MIDDLE Column win

            // ADD VERTICAL | MIDDLE Column | Animation
            // ADD Scanner to find XPiece or OPiece

        }
        else if(winningSpots == WinningNumbers[5]) // RIGHT Column win
        {
            // Debug.Log("{2,5,8}");

            // ADD VERTICAL | RIGHT Column | Animation 
            // ADD Scanner to find XPiece or OPiece

        }
        else if(winningSpots == WinningNumbers[6])
        {
            // Debug.Log("{0,4,8}"); // TOP LEFT to BOTOM RIGHT win

            // ADD DIAGONAL | TOP LEFT to BOTTOM RIGHT | Animation
            // ADD Scanner to find XPiece or OPiece

        }

          else if(winningSpots == WinningNumbers[7])
        {
            // Debug.Log("{2,4,6}"); // BOTTOM LEFT to TOP RIGHT

            // ADD DIAGONAL | BOTTOM LEFT to TOP RIGHT | Animation
            // ADD Scanner to find XPiece or OPiece

        }
        /////////////////
        /////////////////

        //END CASES
    }

    // public void CPUTurn()
    // {
    //     if(cpuChallenger)
    //     {

    //         if(gridSpaces.Length > 1 ){
    //             StartCoroutine(WaitForTurn());
    //             var notTakenSpaces = Array.FindAll<PieceOperator>(gridSpaces, gridSpace => gridSpace.SpotTaken == false );
    //             //Randomize 
    //             var count = notTakenSpaces.Length;
    //             //TODO: Check if there are any spots left, (Length > 0 && != null) if there aren't, exit from this if statement at least
    //             // And Logic to check if player has won already 
    //             var spotToTake = UnityEngine.Random.Range(0, count - 1);

    //             notTakenSpaces[spotToTake].CheckCPUTurn();
    //             Debug.Log("CPU has Chosen: " + notTakenSpaces[spotToTake]);
    //         }

    //     } else
    //     {
    //         Debug.Log("cpuChallenger: " + cpuChallenger);
    //     }
    //     StopCoroutine(WaitForTurn());
    // }

    public IEnumerator WaitForTurn()
    {
        // Debug.Log("Initiating WaitForTurn()...");
        yield return new WaitForSeconds(3f);
        // Debug.Log("ending WaitForTurn()...");

    }

    public void CheckWinConditions()
    {

        foreach(int[] win in WinningNumbers)
        {
            Debug.Log("CHECKING WINNING NUMBERS");

                if(xArray.Contains(win[0]) && xArray.Contains(win[1]) && xArray.Contains(win[2])) // 3 Space Winning combinations
                {
                    // print("X Player -- Well Done.");
                    xWins++;
                    xScore.text = "X Wins: " + xWins; 
                    playerWin = true;
                    GameWinEffect(win); // Passing winning numbers
                    oHealthBar.TakeDamage(7);
                    Debug.Log("O Health Bar: "+ oHealthBar.playerHealth);

                    StartCoroutine(winTextCoroutine());
                    FindObjectOfType<AudioManager>().Play(Sound.SoundType.Explode_VO);

                    return;
                }

                if(oArray.Contains(win[0]) && oArray.Contains(win[1]) && oArray.Contains(win[2]))  // 3 Space Winning Combination
                {
                    // print("O Player -- Well Done.");
                    oWins++;
                    oScore.text = "O Wins: " + oWins; 
                    playerWin = true;
                    GameWinEffect(win); // Passing winning numbers
                    xHealthBar.TakeDamage(7);
                    Debug.Log("X Health Bar: "+ xHealthBar.playerHealth);

                    StartCoroutine(winTextCoroutine());
                    FindObjectOfType<AudioManager>().Play(Sound.SoundType.Obliteration_VO);

                    return;
                }
        
        }

        if(turnManager.turnNumber == 9 && playerWin == false) // TIE GAME will FLASH each gameobject then RESET the game 
        {
            //Insert flash VFX for all pieces
            // Debug.Log("TIE GAME!!");
            turnManager.Reset(firstPlayer);
            resetGame.Reset();
            FindObjectOfType<AudioManager>().Play(Sound.SoundType.Tie);
            FindObjectOfType<AudioManager>().Play(Sound.SoundType.Tie_VO);
        }

    }

}
