using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scr_UIChaperSelect : MonoBehaviour {

	
	
	
	private Text leveNameDisplay;
	private scr_worldController playerScriptRef;
	private GameObject playerContRef;
	
	// Use this for initialization
	void Start () {
		
		
		leveNameDisplay = gameObject.GetComponent<Text>();		//find text component
		
		if (GameObject.Find("PlayerController") != null)						//The timer SHOULD have been saved and brought over from the previous level
		{
			UpdateVariables();
			leveNameDisplay.text = playerScriptRef.selectedLevel;
		}
		else 
		{
			leveNameDisplay.text = "Error: No 'PlayerController' found.";
			leveNameDisplay.fontSize = 20;
		}
	}


	private void UpdateVariables()
	{
		playerContRef = GameObject.Find("PlayerController");
		playerScriptRef = playerContRef.GetComponent<scr_worldController>();
	}

	public void SetAsLevelText()
	{
		leveNameDisplay.text = playerScriptRef.selectedLevel;
	}


}
