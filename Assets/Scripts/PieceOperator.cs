using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceOperator : MonoBehaviour
{
    public GameObject piece;
    public LayerMask layermask; //Research LayerMask
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

                Instantiate( piece, hit.transform.position, hit.transform.rotation);
                // Piece.SetActive(true);

                
                Debug.Log(hit.collider.name);
            }
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
