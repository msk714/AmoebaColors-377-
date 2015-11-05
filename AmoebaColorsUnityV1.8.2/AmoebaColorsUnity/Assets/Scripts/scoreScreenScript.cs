using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreScreenScript : MonoBehaviour {


	private gameScoreScript scoreScriptRef;
	private Text timeDisplay;
	private GameObject timerObject;

	// Use this for initialization
	void Start () {
	
		timeDisplay = gameObject.GetComponent<Text>();		//find text component

		if (GameObject.Find("GameScoreController") != null)						//The timer SHOULD have been saved and brought over from the previous level
		{
			timerObject = GameObject.Find("GameScoreController");		
			scoreScriptRef = timerObject.GetComponent<gameScoreScript>();
			scoreScriptRef.getSavedTime();

			timeDisplay.text = "Time: " + scoreScriptRef.displayTime();


		}
		else 
		{
			timeDisplay.text = "Error: No 'GameScoreController' found.";
			timeDisplay.fontSize = 20;
		}
	}


	void Update()
	{
		timeDisplay.text = "Time: " + scoreScriptRef.timeCur;
	}

}
