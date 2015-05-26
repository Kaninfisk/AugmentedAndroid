using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getTxt : MonoBehaviour {

    public Text getTextFrom;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

        this.GetComponent<Text>().text = getTextFrom.text;

	}
}
