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
    public float force = 700.0f;
    public bool choice = false;

    // Rigidbody test_rb = destroyedVersion.GetComponent<Rigidbody>();
    // public GameObject test_rb = destroyedVersion.GetComponent<Rigidbody>();


    void OnMouseDown()
    {
        Debug.Log("Boom");
        GameObject shatteredX = Instantiate(destroyedVersion, intactVersion.transform.position, intactVersion.transform.rotation);
        intactVersion.SetActive(false);

        Vector3 explosionPos = shatteredX.transform.position; // set position for explosion

        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius); // creates a sphere collider to detect objects

        foreach (Collider nearbyObject in colliders) // for each object in sphere collider
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>(); // obtain Rigidbody component
            if(rb != null) // if contains Rigidbody
            {
                rb.AddExplosionForce(force, explosionPos, radius); // make it explode 
            }

        }


        Destroy(shatteredX, 2f);

        if(!choice)
        {
            choice = true;
            Debug.Log("A Choice has been made True");
            choiceText.SetActive(true);
            StartCoroutine(CreateNewX(intactVersion));
        }

        IEnumerator CreateNewX(GameObject newPiece) 
        {
            yield return new WaitForSeconds(3f);

            intactVersion.SetActive(true);
            choiceText.SetActive(false);
            FindObjectOfType<AudioManager>().Play(Sound.SoundType.Explode);
            StopCoroutine(CreateNewX(intactVersion));
        }

    }
}
