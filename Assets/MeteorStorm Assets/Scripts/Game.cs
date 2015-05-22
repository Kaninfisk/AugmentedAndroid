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
	private bool trackable;
	void Start () {
		slider.enabled = false;
		slider.GetComponent<Image> ().enabled = false;
		slider.maxValue = GameTime;
		trackable = false;

		fill.GetComponent<Image> ().enabled = false;
	}
	public void Istrackable(bool track){
		trackable = track;
		}

	public bool GetTarackable(){
		return trackable;
		}
	// Update is called once per frame
	void Update () {
	if (gameStart) {

			if (trackable) {
				if (slider.value + Time.deltaTime > slider.maxValue) {
					StartStop();	
				}
				slider.value = Mathf.MoveTowards(slider.value,slider.maxValue,Time.deltaTime);
				tottime = tottime + Time.deltaTime;
			}

			//Debug.Log("Deltatime = " + Time.deltaTime + "totaltime in Milliseconds = " + tottime);
				}
	}

	public void StartStop(){
		Debug.Log ("StartStop");
		if (trackable) {
			gameStart = !gameStart;
			for (int i = 0; i < SpawnerArray.Length; i++) {
				SpawnerArray[i].GetComponent<SpawnScript>().StartStop();
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

}
