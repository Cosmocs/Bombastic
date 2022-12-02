using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Try to make invisible animation instead of code.


public class cameraFollow : MonoBehaviour
{
    //Attach this script to your camera

    //2. camera movement (not smooth)

    //private float panWidth;
    private Vector3 previousPan; //the last time the camera is moved
    private Vector3 offset; //so the camera is not directly onto the player

    //drag the player object from Hiearchy window to the box in the inspector
    public GameObject player;

    //drag the camera object from Hiearychy window to the box in the inspector
    public Camera camera;
    private float halfHeight;
    private float moveWidth;
    private float moveHeight;
    public float movementDivider;

    // Start is called before the first frame update
    void Start()
    {
        //to get the half height and half width of the camera
        halfHeight = camera.orthographicSize;
        moveWidth = camera.aspect * halfHeight / movementDivider;
        moveHeight = halfHeight * 2f / movementDivider;
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
        if (Mathf.Abs(previousPan.x - player.transform.position.x) > moveWidth)
        {
            previousPan = transform.position;
        }else if (Mathf.Abs(previousPan.y - player.transform.position.y) > moveHeight)
        {
            previousPan = transform.position;
        }
        transform.position = previousPan;
    }
}
