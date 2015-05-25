using UnityEngine;
using System.Collections;

public class ExitLevelCollider : MonoBehaviour {

	DashManager manager;

	// Use this for initialization
	void Start ()
	{
		manager = GameObject.FindWithTag ("Manager").GetComponent<DashManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		//If player collides, the game is won! :D
		if (other.tag == "Player")
		{
			manager.gameWon = true;
			manager.gameRunning = false;
			Debug.Log ("You won the game!");
		}
	}
}
