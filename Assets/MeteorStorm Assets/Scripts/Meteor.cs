using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	public float MovementSpeed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	//	this.transform.Rotate(Vector3.right * 10f * Time.deltaTime);
	//	this.transform.Rotate (Vector3.up * 5f * Time.deltaTime);
		this.transform.Translate (Vector3.up * MovementSpeed * Time.deltaTime);
	}
}
