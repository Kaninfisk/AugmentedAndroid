using UnityEngine;
using System.Collections;
using Vuforia;

public class MovementScript : MonoBehaviour {
	
	Touch currentTouch;
	bool isGrounded;
	float distToGround;
	float distToSide;
	bool jumping;
	public float jumpForce;
	bool sideCollision;
	DashManager manager;



	// Use this for initialization
	void Start ()
	{
		//Set the distance to ground to be the distance from the center to the edge of the box
		distToGround = collider.bounds.extents.y;
		distToSide = collider.bounds.extents.x;

		//Sets the gravity in order to improve the feel of the jump
		Physics.gravity = new Vector3(0, -150.0f, 0);
		jumping = false;
		jumpForce = 35;

		manager = GameObject.FindWithTag ("Manager").GetComponent<DashManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Check whether the player is grounded by raycasting from center to edge of box
		isGrounded = Physics.Raycast(new Ray(transform.position, Vector3.down), distToGround + 0.1f, 1);
		//Debug.Log ("isGrounded = " + isGrounded.ToString ());

		//Check whether the player is colliding from the side
		sideCollision = Physics.Raycast(new Ray(transform.position, Vector3.right), distToSide, 1);
		//Debug.Log ("sideCollision = " + sideCollision.ToString ());

		//Test for PC - sets jumping to true if space is pressed while grounded
		if (manager.gameRunning && Input.GetKey(KeyCode.Space) && isGrounded)
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
		if (manager.gameRunning && currentTouch.phase == TouchPhase.Began && isGrounded)
		{
			//Needs to be commented out when testing on PC
	  		//jumping = true;
		}
		//Ends the game if player collides with an obstacle
		if (sideCollision && ! manager.gameOver)
		{
			if (!manager.gameOver)
			{
				Debug.Log ("Game over!");
				manager.gameRunning = false;
				Debug.Log ("Movement gameRunning = " + manager.gameRunning);
				manager.gameOver = true;
			}

		}

		//Reset shortcut for testing purposes
		if (Input.GetKey(KeyCode.R))
		{
			manager.ResetLevel();
		}
	}

	void FixedUpdate()
	{
		//jumps if user presses space while grounded
		if (jumping) {
				rigidbody.velocity = Vector3.up * jumpForce;
				jumping = false;
		}

		//Rotates player while game is running
		if (manager.gameRunning && !manager.gameOver && !manager.gameWon)
		{
			transform.Rotate (Vector3.back * Time.deltaTime * 500);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("Player collided...");
		if (collision.collider.tag == "Spike")
		{
			Debug.Log ("...with a spike! :D");
			manager.gameOver = true;
			manager.gameRunning = false;
		}
	}

}
