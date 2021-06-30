using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Destructible : MonoBehaviour
{
    public GameObject intactVersion;
    public GameObject destroyedVersion;
    public GameObject choiceText;
    public float radius = 5.0f;
    public float force = 10.0f;
    public bool choice = false;

    // Rigidbody test_rb = destroyedVersion.GetComponent<Rigidbody>();
    // public GameObject test_rb = destroyedVersion.GetComponent<Rigidbody>();

    void OnMouseDown()
    {
        Debug.Log("Boom");
        Instantiate(destroyedVersion, transform.position, transform.rotation);

        destroyedVersion.GetComponent<Rigidbody>().useGravity = false;
        destroyedVersion.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
        Destroy(intactVersion); // This Instance Dies here.


        if(!choice)
        {
            bool choice = true;
            Debug.Log("A Choice has been made True");
            choiceText.SetActive(true);
        }
        
        Rigidbody rb = destroyedVersion.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddExplosionForce(force, transform.position, radius);

        Destroy(destroyedVersion, 3f);


    }
}
