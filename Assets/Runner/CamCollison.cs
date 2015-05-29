using UnityEngine;
using System.Collections;

public class CamCollison : MonoBehaviour {

	public GameObject target;

	void OnTriggerEnter(Collider collision) 
	{
		if(collision.transform.name == "3rd Person Controller")
		{
			target.SendMessage("StopGame", true);
		}
		Debug.Log (collision.name);
	}
	
	void OnTriggerExit(Collider collision) 
	{
		if(collision.transform.name == "3rd Person Controller")
		{
			target.SendMessage("StopGame", false);
		}
	}


}
