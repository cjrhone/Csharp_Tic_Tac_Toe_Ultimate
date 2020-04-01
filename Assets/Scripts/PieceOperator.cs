using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceOperator : MonoBehaviour
{
    public GameObject Piece;
    public LayerMask layermask;
    public float rayLength;

    public void Update()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        //Research GetMouseButton and EventSystem
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, layermask))
            {
                bool isActive = Piece.activeSelf;
                Piece.SetActive(!isActive);

                Debug.Log(hit.collider.name);
            }
            //DEFINTELY change this to "OnClick" button style pressing
            //Right now VERY sensitive to button clicks 
        }
        // if(Piece != null)
        // {
        //     Piece.SetActive(true);
        // }
    }

    //useful raycast code
    // RaycastHit hit;
    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

}
