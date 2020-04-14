using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinthatbitch : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( new Vector3(10,40,45) * Time.deltaTime);
        
    }
}
