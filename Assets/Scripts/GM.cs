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

    public int counter = 0;

    public int xWins;

    public int oWins;

    PlayerPiece XorO;

    public Button[] gridSpaces;

    private int[][] WinningNumbers = new int[8][];

    public List<int> xArray = new List<int>();
    public List<int> oArray = new List<int>();

    public Text spaceText;
    public Text winText;

    public Text xScore;
    public Text oScore;
    public bool playerWin = false;


    public ResetGame resetGame; // SCRIPT FOR ResetGame
    public GameObject resetButton; // GAMEOBJECT for resetButton to make appear, reappear -- refactor to retry button later 

    public PieceOperator pieceOperator;

    public HealthBar xHealthBar; // X HEALTH BAR REFERENCE
    public HealthBar oHealthBar; // O HEALTH BAR REFERENCE 

    public int maxHealth = 25; // DEFAULT MAX HEALTH
    public int oCurrentHealth; // CURRENT HEALTH for Player O
    public int xCurrentHealth; // CURRENT HEALTH for Player X





    void Start()
    {
        // A GOOD PLACE FOR A COROUTINE

        print("STARTING: maxHealth: " + maxHealth);
        oCurrentHealth = maxHealth;
        xCurrentHealth = maxHealth;

        xHealthBar.SetMaxHealth(maxHealth);
        oHealthBar.SetMaxHealth(maxHealth);


        print("O Current Health: " + oCurrentHealth);
        print("X Current Health: " + xCurrentHealth);

        print("Max Health: " + maxHealth);


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

        xScore.text = "X Wins: " + xWins; 
        oScore.text = "O Wins: " + oWins;  

    }

     public void TakeDamage( int damage, int playerHealth, HealthBar healthbar ) // Will include TIME BONUS feature for extra damage in the near future
    {
        print("damage: " + damage);
        print("playerHealth: " + playerHealth);
        print("healthbar: " + healthbar);

        playerHealth -= damage;
        
        if( healthbar == xHealthBar ) // CHECK REFERENCE FOR WHICH HEALTHBAR
        {
            xCurrentHealth = playerHealth;
            xHealthBar.SetHealth(xCurrentHealth);

            print("X CONDITION");
        }

        else if( healthbar == oHealthBar ) // CHECKS REFERENCE FOR WHICH HEALTHBAR
        {
            oCurrentHealth = playerHealth;
            oHealthBar.SetHealth(oCurrentHealth);
            print("O CONDITION");
        }

        // healthbar.SetHealth(playerHealth);
        // print("After SetHealth playerhealth now is: " + playerHealth);
        // print("xHealth: " + xCurrentHealth);
        // print("oHealth: " + oCurrentHealth);

       

    }

    IEnumerator winTextCoroutine()
    {
        // Debug.Log("winText COROUNTINE ACTIVE");

         if( oCurrentHealth <= 0 || xCurrentHealth <= 0) // PLAYER < 0 HEALTH
        {
            Debug.Log("ENDING COROUTINE...");
            winText.GetComponent<Text>().enabled = true; //enables Win Text on GameWin
            resetButton.SetActive(true);
            StopCoroutine(winTextCoroutine()); // STOP Coroutine 
            yield return null;
        }

        else if (playerWin == true)
        {
            Debug.Log("INITIATING WAITFORSECONDS...");
            yield return new WaitForSeconds(1);
            resetGame.Reset();
        }
        Debug.Log("PlayerWin: " + playerWin);
        yield return null;

    }

    public void GameWin(int[] winningSpots)
    {
        FindObjectOfType<AudioManager>().Play("Damage");


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
            space.interactable = false;
            counter = 0;
        }

        //   winText.GetComponent<Text>().enabled = true; //enables Win Text on GameWin


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
                            xScore.text = "X Wins: " + xWins; 
                            playerWin = true;
                            GameWin(win);

                            TakeDamage(7, oCurrentHealth, oHealthBar);

                            // if( oCurrentHealth <= 0) // PLAYER < 0 HEALTH
                            // {
                            //     StopCoroutine(winTextCoroutine());
                            //     Debug.Log("X GAME WIN!");
                            //     winText.GetComponent<Text>().enabled = true; //enables Win Text on GameWin
                            //     resetButton.SetActive(true);

                            // }

                            StartCoroutine(winTextCoroutine());
                            return;
                        }

                        if(oArray.Contains(win[0]) && oArray.Contains(win[1]) && oArray.Contains(win[2]))
                        {
                            print("O Player -- Well Done.");
                            oWins++;
                            oScore.text = "O Wins: " + oWins; 
                            playerWin = true;
                            GameWin(win);
                            TakeDamage(7, xCurrentHealth, xHealthBar);

                            //  if( xCurrentHealth <= 0) // PLAYER < 0 HEALTH
                            // {
                            //     StopCoroutine(winTextCoroutine());
                            //     Debug.Log("O GAME WIN!");
                            //     winText.GetComponent<Text>().enabled = true; //enables Win Text on GameWin
                            //     resetButton.SetActive(true);

                            // }

                            StartCoroutine(winTextCoroutine());


                            
                            return;
                        }
               
                }

    }

        if(counter == 9 && playerWin == false) // TIE GAME will FLASH each gameobject then RESET the game 
        {
            Debug.Log("TIE GAME!!");
            resetGame.Reset();

        }

    }

}
