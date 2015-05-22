using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		//Destroys level objects when they collide
		Debug.Log ("Entered OnTriggerEnter");
		Destroy (other);
	}
}
