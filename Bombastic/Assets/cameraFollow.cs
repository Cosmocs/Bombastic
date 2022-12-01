using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    //Attach this script to your camera

    //2. camera movement (not smooth)

    //private float panWidth;
    private Vector3 previousPan; //the last time the camera is moved
    private Vector3 offset; //so the camera is not directly onto the player

    //drag the player object from Hiearchy window to the box in the inspector
    public GameObject player; //to access the player object. Here it is the red circle.
    //drag the camera object from Hiearychy window to the box in the inspector
    public Camera camera;
    private float halfHeight;
    private float halfWidth;


    // Start is called before the first frame update
    void Start()
    {
        //to get the half height and half width of the camera
        halfHeight = camera.orthographicSize;
        halfWidth = camera.aspect * halfHeight;
        //maintain the relative offset
        offset = transform.position - player.transform.position; 
        previousPan = transform.position; //initially the previousPan = original position
    }

    // Update is called once per frame
    void Update()
    {
        //to make sure the camera does not rotate
        transform.position = player.transform.position + offset;
        //check if the player has moved the half of the camera width
        //if yes, change the PreviousPan variable to the new location.
        //if not, make the camera stay. 
        if (Mathf.Abs(previousPan.x - player.transform.position.x) > halfWidth/6.0)
        {
            previousPan = transform.position;
        }
        transform.position = previousPan;
    }
}
