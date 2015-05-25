using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DashManager : MonoBehaviour {

	public bool gameRunning;
	public bool gameWon;
	public bool gameOver;
	public GameObject level;
	public Button button;
	public Text loseText;
	public Text winText;
	GameObject runningLevel;
	GameObject player;

	//Next up: Implementing sounds!

	GameObject target;

	// Use this for initialization
	void Start ()
	{
		//Finding the image target and player for the reset method
		target = GameObject.FindWithTag ("ImageTarget");
		player = GameObject.FindWithTag ("Player");
		winText.gameObject.SetActive (false);
		//button = GameObject.FindWithTag ("Button").GetComponent<Button>();
		//loseText = GameObject.FindWithTag ("LoseText").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//shows loseText + restart button and disables moevement when player dies
		if (gameOver)
		{
			winText.gameObject.SetActive(false);
			loseText.gameObject.SetActive(true);
			ShowButton();
			player.GetComponent<MovementScript>().enabled = false;
		}
		else if (gameWon)
		{
			winText.gameObject.SetActive(true);
			loseText.gameObject.SetActive(false);
			HideButton ();
			player.GetComponent<MovementScript>().enabled = false;
		}
		else
		{
			winText.gameObject.SetActive(false);
			loseText.gameObject.SetActive(false);
		}


	}

	public void ResetLevel()
	{
		gameOver = false;
		gameRunning = true;
		Debug.Log ("Dash gameRunning = " + gameRunning.ToString ());
		//Destroying old level
		Destroy (runningLevel);
		Debug.Log("Level destroyed");
		//Making new level
		runningLevel = (GameObject)Instantiate (level, new Vector3 (2, 0, 0), Quaternion.identity);
		runningLevel.transform.SetParent(target.transform, false);
		//Resetting player position and game bools
		player.transform.position = new Vector3(-0.4f, 0.1f, 0);
		player.GetComponent<MovementScript> ().enabled = true;
		gameOver = false;
		HideButton ();
	}

	public void ShowButton()
	{
		button.gameObject.SetActive (true);
	}

	public void HideButton()
	{
		button.gameObject.SetActive (false);
	}
}
