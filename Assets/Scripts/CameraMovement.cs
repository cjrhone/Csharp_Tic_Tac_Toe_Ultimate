using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public Camera mainCamera;
    public Button moveButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void MoveCamera()
    {
        mainCamera.transform.Translate( new Vector3(0,0,-11) * Time.deltaTime);

    }
}
