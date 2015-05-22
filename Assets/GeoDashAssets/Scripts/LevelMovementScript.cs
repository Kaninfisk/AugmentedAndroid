/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;
using Vuforia;

public class LevelMovementScript : MonoBehaviour
{
	Vector3 origPos;

	void Start()
	{
		origPos = transform.position;
	}

	//Egne metoder
	void Update()
	{

	}

	void FixedUpdate()
	{
		Debug.Log ("gameRunning = " + GeoDashTrackableEventHandler.gameRunning.ToString ());
		if (GeoDashTrackableEventHandler.gameRunning)
		{
			Debug.Log ("Moving level");
			this.transform.position = new Vector3 (transform.position.x - 0.2f, 0, 0);
		}
	}
}

