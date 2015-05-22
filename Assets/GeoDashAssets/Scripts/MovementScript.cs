using UnityEngine;
using System.Collections;
using Vuforia;

public class MovementScript : MonoBehaviour {
	
	Touch currentTouch;
	bool isGrounded;
	float distToGround;
	float distToSide;
	bool jumping;
	bool sideCollision;



	// Use this for initialization
	void Start ()
	{
		//Set the distance to ground to be the distance from the center to the edge of the box
		distToGround = collider.bounds.extents.y;
		distToSide = collider.bounds.extents.x;

		//Sets the gravity in order to improve the feel of the jump
		Physics.gravity = new Vector3(0, -150.0f, 0);
		jumping = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Check whether the player is grounded by raycasting from center to edge of box
		isGrounded = Physics.Raycast(new Ray(transform.position, Vector3.down), distToGround + 0.1f, 1);
		//Debug.Log ("isGrounded = " + isGrounded.ToString ());

		//Check whether the player is colliding from the side
		sideCollision = Physics.Raycast(new Ray(transform.position, Vector3.right), distToSide - 0.1f, 1);
		//Debug.Log ("sideCollision = " + sideCollision.ToString ());

		//Test for PC - sets jumping to true if space is pressed while grounded
		if (Input.GetKey(KeyCode.Space) && isGrounded)
		{
			//Debug.Log ("Space was pressed");
			jumping = true;
		}
		//Get input
		if (Input.touches.Length > 0)
		{
			currentTouch = Input.GetTouch(0);
		}
		//If a touch is registered and the player is grounded, the player jumps
		if (currentTouch.phase == TouchPhase.Began && isGrounded)
		{
			//Needs to be commented out when testing on PC
	  		//jumping = true;
		}
		if (sideCollision)
		{
			Debug.Log ("Game over!");
			GeoDashTrackableEventHandler.gameRunning = false;
		}
	}

	void FixedUpdate()
	{
		//jumps if user presses space while grounded
		if (jumping) {
				//rigidbody.AddForce(Vector3.up * jumpForce);
				rigidbody.velocity = Vector3.up * 40;
				jumping = false;
		}

		if (GeoDashTrackableEventHandler.gameRunning)
		{
			//Applies a rotation to sphere
			transform.Rotate (-Vector3.forward * Time.deltaTime * 500);
		}
	}

}
