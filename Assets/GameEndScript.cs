using UnityEngine;
using System.Collections;

public class GameEndScript : MonoBehaviour {
	public GameObject Gameinfo;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider other){
		Debug.Log ("this Works");
		Gameinfo.GetComponent<Game> ().StartStop ();
		}
	// Update is called once per frame
	void Update () {
	
	}
}
