using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	
	public float jumpForce = 4000;


	Touch currentTouch;
	public bool isGrounded;
	float distToGround;
	bool jumping = false;



	// Use this for initialization
	void Start ()
	{
		//Set the distance to ground to be the distance from the center to the edge of the box
		distToGround = collider.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Check whether the player is grounded by raycasting from center to edge of box
		isGrounded = Physics.Raycast(new Ray(transform.position, Vector3.down), distToGround + 0.1f, 1);
		Debug.Log ("isGrounded = " + isGrounded.ToString ());

		//Test for PC - sets jumping to true if space is pressed while grounded
		if (Input.GetKey(KeyCode.Space) && isGrounded)
		{
			Debug.Log ("Space was pressed");
			jumping = true;
		}
		//Get input
		if (Input.touches.Length > 0)
		{
			currentTouch = Input.touches [0];
		}
	}

	void FixedUpdate()
	{

		//If a touch is registered and the player is grounded, the player jumps
		if (currentTouch.phase == TouchPhase.Began && isGrounded)
		{
			//rigidbody.AddForce(Vector3.up * jumpForce);
		}

		//jumps if user presses space while grounded
		if (jumping)
		{
			rigidbody.AddForce(Vector3.up * jumpForce);
			jumping = false;
		}
	}

}
