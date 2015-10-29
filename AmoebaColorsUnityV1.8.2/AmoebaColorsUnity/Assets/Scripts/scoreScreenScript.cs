using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreScreenScript : MonoBehaviour {


	private gameScoreScript scoreScriptRef;
	private Text timeDisplay;

	// Use this for initialization
	void Start () {
	
		timeDisplay = gameObject.GetComponent<Text>();		//find text component

		if (GameObject.Find("GameScoreController") != null)						//The timer SHOULD have been saved and brought over from the previous level
		{
			GameObject timerObject = GameObject.Find("GameScoreController");		
			scoreScriptRef = timerObject.GetComponent<gameScoreScript>();
			scoreScriptRef.getSavedTime();

			timeDisplay.text = "Time: " + scoreScriptRef.displayTime();

			DestroyObject(timerObject);		//We must destroy the timer/GameScoreController object or else it wll carry over to the next level and mutiple ones might be present
		}
		else 
		{
			timeDisplay.text = "Error: No 'GameScoreController' found.";
			timeDisplay.fontSize = 20;
		}
	}

}
