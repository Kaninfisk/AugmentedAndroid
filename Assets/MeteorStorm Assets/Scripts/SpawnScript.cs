using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {


	public GameObject[] obj;
	public int spawnMin;
	public int spawnMax;
	public bool GameRunning = false;
	public bool SpawnInit = true;
	private GameObject GameInfo;

	// Use this for initialization
	void Start () {
		GameInfo = GameObject.Find ("GameInfo");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("In Update");
			
		if (GameRunning && SpawnInit) {
			Spawn ();	
				}

		}

	public void StartStop(){
		Debug.Log ("Start spawner");
		GameRunning = !GameRunning;
		SpawnInit = true;
	}
	void Spawn(){
			if (GameRunning) {
			Instantiate(obj[Random.Range(0,obj.Length)], transform.position, Quaternion.identity);
			Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
			SpawnInit = false;
		}
			
				}

	}

