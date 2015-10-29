using UnityEngine;
using System.Collections;

public class goal_finishLevel : MonoBehaviour {
	
	
	public GameObject gameScoreController;
	public int levelIndex;
	public string levelSceneName;
	
	
	//get ScriptS to Save
	private gameScoreScript scoreScriptRef;
	
	
	
	
	public void NextLevel(int index)
	{
		Application.LoadLevel(index);
	}
	
	public void NextLevel(string levelName)
	{
		Application.LoadLevel(levelName);
	}
	
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")		//only activate if a player object runs into the goal
		{
			//other.gameObject.SetActiveRecursively(false);
			DestroyObject(other.gameObject);
			
			GameObject[] listOfPlayers = GameObject.FindGameObjectsWithTag("Player");
			Debug.Log (listOfPlayers.Length);
			if (listOfPlayers.Length-1 == 0)
			{
				//Get the timer script from the game object, stop it, then save the time
				scoreScriptRef = gameScoreController.GetComponent<gameScoreScript>();
				scoreScriptRef.stopTimer();
				scoreScriptRef.saveTime();
				
				NextLevel(levelIndex);
				NextLevel(levelSceneName);
			}
		}
	}
}