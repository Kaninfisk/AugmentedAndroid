using UnityEngine;
using System.Collections;

public class Finishline : MonoBehaviour {

	public GameObject target;
	
	void OnTriggerEnter(Collider collision) 
	{
		if(collision.transform.name == "3rd Person Controller")
		{
			target.SendMessage("GameFinish", true);
		}
	}
}
