using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
			if (other.tag == "Player") 
			{
			Application.LoadLevel(1);
			return;
			}
			
			if (other.gameObject.transform.parent) {
						Destroy (other.gameObject.transform.parent.gameObject);
				} else {
			Destroy(other.gameObject);
				}
	}
}
