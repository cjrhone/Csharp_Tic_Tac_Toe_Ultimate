using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;
    public float radius = 5.0f;
    public float force = 10.0f;

    void OnMouseDown()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        // Destroy(gameObject);
        
        Rigidbody rb = destroyedVersion.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddExplosionForce(force, transform.position, radius);

        Destroy(destroyedVersion, 3f);
        Destroy(gameObject);


    }
}
