using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class spinthatbitch : MonoBehaviour
{
    bool isX;
    bool isInWinState;
    bool isRotatingToWinPosition;
    Camera cameraRef;

    Quaternion winPositionX;
    Quaternion winPositionO;

    float animationRotationTimeSeconds = 0.50f;
    float animationSpeed = 4.0f;
    float animationStartTimeMSec;
    float animationEndTimeMSec;

    //Explosion
    public GameObject shatteredPiece;
    public float radius = 5.0f;
    public float force = 700.0f;

    void Start (){
        cameraRef = GameObject.FindObjectOfType<Camera>();
        winPositionX = Quaternion.Euler(-90f, 0f, 90f);
        winPositionO = Quaternion.Euler(0f, 0f, 90f);
        isX = gameObject.name.Contains("x"); //ALERT ALERT IF GAMEOBJECT NAME CHANGES, THIS NEEDS TO BE LOOKED AT
    }

    // Update is called once per frame
    void Update()
    {
        if(isInWinState){
            //Rotate teh Piece so that it faces the camera, that rotation angle is determined by the x,y,z values in winPosition.
            if(isRotatingToWinPosition){
                //Check if the difference between our current rotation (transform.eulerAngles) and our destinantion rotation (winPosition) is large enough that we should keep on rotating
                // if the difference is too small, then set the final rotation values to the object (we've rotated enough that we don't have to animate frame by frame anymore).
                if(Time.time < animationEndTimeMSec){ 
                    //Every frame, we are calculating a small chunk to rotate the object by that gets us closer to the destination (winPosition), we then set the current rotation values
                    //to add that small chunk to the object's rotation, eventually getting as close as possible to the destination.
                    transform.rotation = Quaternion.Lerp(transform.rotation, isX ? winPositionX : winPositionO, animationSpeed * Time.deltaTime);
                } else {
                    //set the final rotation to the object, we're done animating!
                    transform.rotation = isX ? winPositionX : winPositionO;
                    isRotatingToWinPosition = false;

                    StartCoroutine(WaitToExplode());
                }
            }
        } else { //default
            transform.Rotate( new Vector3(10,40,45) * Time.deltaTime);  
        }
    }


    // Plays a special animation on the winning pieces
    [ContextMenu("PlayWinAnimation")]
    public void PlayWinAnimation(){
        isInWinState = true;
        isRotatingToWinPosition = true;
        animationStartTimeMSec = Time.time;
        animationEndTimeMSec = animationStartTimeMSec + animationRotationTimeSeconds;

        Debug.Log($"StartTime is {animationStartTimeMSec} End time is {animationEndTimeMSec}");
        //Do special stuff
    }

    // private IEnumerator WinAnimation(){
    //     while(isInWinState) {
              
    //     }
    // }


    //Returns the piece back to initial state
    public void ResetAnimation(){
        isInWinState = false;
    }

    public IEnumerator WaitToExplode()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("SETS PIECE INACTIVE -- THEN INSTANTIATE EXPLOSION!");
        gameObject.SetActive(false);

        GameObject explosionPiece = Instantiate(shatteredPiece, gameObject.transform.position, gameObject.transform.rotation);

        Vector3 explosionPos = explosionPiece.transform.position; // set position for explosion

        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius); // creates a sphere collider to detect objects

        foreach (Collider nearbyObject in colliders) // for each object in sphere collider
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>(); // obtain Rigidbody component
            if(rb != null) // if contains Rigidbody
            {
                rb.AddExplosionForce(force, explosionPos, radius); // make it explode 
            }

        }

        Destroy(explosionPiece, 3f);
    }
}
