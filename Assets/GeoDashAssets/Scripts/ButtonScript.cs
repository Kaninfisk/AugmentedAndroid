using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	DashManager manager;

	// Use this for initialization
	void Start ()
	{
		manager = GameObject.FindWithTag ("Manager").GetComponent<DashManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onClick()
	{
		manager.ResetLevel ();
		manager.HideButton ();
	}
}
