﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PieceOperator : MonoBehaviour
{
    public GameObject Piece;
    public GameObject XPiece;
    public GameObject OPiece;
    public Turn currentTurn;
    public Button button;

    public Text buttonText;

    PlayerPiece currentState;
    

    public void PlacePiece() 
    {
        
        if (Piece != null)
        {
            bool isActive = Piece.activeSelf;
            
            Piece.SetActive(!isActive); // May be unecessary but keep for now 

            Debug.Log("you clicked: " + Piece);

            buttonText.text = currentTurn.currentState.ToString(); //Placing the Piece

            currentTurn.NextTurn();

             button.interactable = false;

             // Check Win Conditions

             // Increment Counter for Tie game ... Something like if counter > 9 == Show "Tie Game" text



        }

    }

    // public void NextTurn()
    // {
    //     currentState = (PlayerPiece)(((int)currentState + 1 ) % 3);

    //     Debug.Log("current state: " + currentState);


    //     // NextTurn will cycle the turn, incrementing up or resetting to P1 
    // }

    public void TestFunction()
    {
        Debug.Log("TEST FUNCTION WORKING!");
    }

    public void Update()
    {


        // RAYCAST UPDATES CLICK EVERY FRAME, WHICH WE DON'T WANT
        // if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        // //Research GetMouseButton and EventSystem
        // {

        //     RaycastHit hit;
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     if (Physics.Raycast(ray, out hit, rayLength, layermask))
        //     {

        //         Instantiate( piece, hit.transform.position, hit.transform.rotation);
        //         piece.SetActive(true);

                
        //         Debug.Log(hit.collider.name);
        //     }
        }
       
    }
