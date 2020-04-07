using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceOperator : MonoBehaviour
{
    public GameObject Piece;

    public void PlacePiece() 
    {
        if (Piece != null)
        {
            bool isActive = Piece.activeSelf;
            
            Piece.SetActive(!isActive);
        }
    }

    public void Update()
    {


        // RAYCAST WORKS EVERY FRAME, WHICH WE DON'T WANT
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
