using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballDetect : MonoBehaviour
{
    //Attach the script to the player.
    //My player object is a red Circle.

    private Rigidbody2D rb;
    //public so the number can be changed inside Unity.
    //Can also be private. Not a big deal. 
    public float initialVelocityX;


    // Start is called before the first frame update
    private void Start()
    {
        //1. Hitting and knocking over the wall
        //The below two lines of code gives an object an intial velocity
        //on top of the ball's collider2D and Rigidbody2D.
        //The Object being hit also needs to have Collider2D at least.
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (initialVelocityX, rb.velocity.y);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //3. onTriggerEnter2D doesn't work above
        //So unfortunately, the boxes only work when it's not actually collding.
        //Aka, there should be some sort of overlap.
        //But you can have two colliders attach to the same object.
        //So in the simple ball, wall, platform scene I have earlier, in order
        //for the ball to hit the wall, knock it out, and this script being trigger,
        //You need the ball to have Collider2D, RigidBody2D, the platform have Collider2D,
        //And the wall (very important!) have:
        //- 1. Rigid Body 2D
        //- 2. Box Collider 2D WITH is Trigger checked (so it tells script it is a trigger)
        //- 3. Box Collider 2D WITHOUT is Trigger checked (so it actually collides with ball/platform)
        Debug.Log("GameObject collided");
        //if you want to tell what exact object you are colliding to: tag the object
        //tag is in inspector--> at very top just below the name "Tag"
        //And then use: if(other.gameObject.CompareTag("TheNameOfTheTag"){}
        // --> other in the above code is the name of the collider in this private class
    }


}
