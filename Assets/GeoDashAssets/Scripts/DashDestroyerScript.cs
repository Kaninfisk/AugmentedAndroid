using UnityEngine;
using System.Collections;

public class DashDestroyerScript : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		//Destroys level objects when they collide
		Debug.Log ("Entered OnTriggerEnter");
		Destroy (other);
	}
}
