using UnityEngine;

public class spinthatbitch : MonoBehaviour
{
    bool isInWinState;
    bool isRotatingToWinPosition;
    Camera cameraRef;

    Vector3 winPosition = new Vector3 (-90f, 0f, 90f);

    void Start (){
        cameraRef = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInWinState){
            //Rotate teh Piece so that it faces the camera, that rotation angle is determined by the x,y,z values in winPosition.
            if(isRotatingToWinPosition){
                //Check if the difference between our current rotation (transform.eulerAngles) and our destinantion rotation (winPosition) is large enough that we should keep on rotating
                // if the difference is too small, then set the final rotation values to the object (we've rotated enough that we don't have to animate frame by frame anymore).
                if(Vector3.SqrMagnitude(transform.eulerAngles - winPosition) > 0.0001f){ 
                    //Every frame, we are calculating a small chunk to rotate the object by that gets us closer to the destination (winPosition), we then set the current rotation values
                    //to add that small chunk to the object's rotation, eventually getting as close as possible to the destination.
                    transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, winPosition, Time.deltaTime);
                    Debug.Log($"Still Rotating for {gameObject.name}");
                } else {
                    //set the final rotation to the object, we're done animating!
                    transform.eulerAngles = winPosition;
                    isRotatingToWinPosition = false;
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
}
