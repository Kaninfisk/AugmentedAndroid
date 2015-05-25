using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

	DashManager manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.FindWithTag ("Manager").GetComponent<DashManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("Spike collided...");
		if (collision.collider.tag == "Player")
		{
			Debug.Log("...with a player! :D");
			manager.gameOver = true;
			manager.gameRunning = false;
		}
	}

}
