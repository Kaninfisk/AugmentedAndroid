using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Game : MonoBehaviour {
	public Slider slider;
	public Button button;
	public GameObject fill;
	public GameObject[] SpawnerArray;
	// Use this for initialization
	public float GameTime = 10;
	private bool gameStart = false;
	private float tottime = 0f;
	void Start () {
		slider.enabled = false;
		slider.GetComponent<Image> ().enabled = false;
		slider.maxValue = GameTime;
		button.GetComponentInChildren<Text> ().fontSize = 80;
		button.GetComponentInChildren<Text> ().text = "Press Play to Start";

		fill.GetComponent<Image> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	if (gameStart) {
			if (slider.value + Time.deltaTime > slider.maxValue) {
				StartStop();	
			}
			slider.value = Mathf.MoveTowards(slider.value,slider.maxValue,Time.deltaTime);
			tottime = tottime + Time.deltaTime;
			//Debug.Log("Deltatime = " + Time.deltaTime + "totaltime in Milliseconds = " + tottime);
				}
	}

	public void StartStop(){
		gameStart = !gameStart;
		for (int i = 0; i < SpawnerArray.Length; 0++) {

				}
		slider.value = 0;
		button.enabled = !button.enabled;
		button.image.enabled= !button.image.enabled;
		slider.enabled = !slider.enabled;
		slider.GetComponent<Image> ().enabled = !slider.GetComponent<Image> ().enabled;
		fill.GetComponent<Image> ().enabled = !fill.GetComponent<Image> ().enabled;
		button.GetComponentInChildren<Text> ().enabled = !button.GetComponentInChildren<Text> ().enabled;
	}
}
