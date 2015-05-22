/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;
using Vuforia;

public class LevelMovementScript : MonoBehaviour
{
	DashManager manager;

	void Start()
	{
		manager = GameObject.FindWithTag ("Manager").GetComponent<DashManager> ();
	}

	//Egne metoder
	void Update()
	{

	}

	void FixedUpdate()
	{
		//Debug.Log ("Level gameRunning = " + manager.gameRunning.ToString ());
		//Moves the level towards the player while the game is running
		if (manager.gameRunning && !manager.gameOver)
		{
			Debug.Log ("Moving level");
			this.transform.position = new Vector3 (transform.position.x - 0.4f, 0, 0);
		}
	}
}

