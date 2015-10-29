using UnityEngine;
using System.Collections;

public class buttonNextLevel : MonoBehaviour {



	public void DestroyScoreObject()
	{
		if (GameObject.Find("GameScoreController") != null)						//The timer SHOULD have been saved and brought over from the previous level
		{
			GameObject controllerObj = GameObject.Find("GameScoreController");	
			DestroyObject(controllerObj);		//We must destroy the timer/GameScoreController object or else it wll carry over to the next level and mutiple ones might be present
		}
	}



	public void NextLevelButton(int index)
	{
		Application.LoadLevel(index);
	}
	
	public void NextLevelButton(string levelName)
	{
		Application.LoadLevel(levelName);
	}
	public void PreviousLevelButton()
	{
		if (GameObject.Find("GameScoreController") != null)						//The timer SHOULD have been saved and brought over from the previous level
		{
			GameObject controllerObj = GameObject.Find("GameScoreController");	
			gameScoreScript ControllerScriptRef;
			ControllerScriptRef = controllerObj.GetComponent<gameScoreScript>();

			Application.LoadLevel(ControllerScriptRef.getLastlevel());

			DestroyObject(controllerObj);		//We must destroy the timer/GameScoreController object or else it wll carry over to the next level and mutiple ones might be present
		}
	}
}
