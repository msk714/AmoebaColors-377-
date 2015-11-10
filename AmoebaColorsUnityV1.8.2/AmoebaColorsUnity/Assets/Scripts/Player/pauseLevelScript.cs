using UnityEngine;
using System.Collections;

public class pauseLevelScript : MonoBehaviour {



	public bool gamePause;
	public Vector2 buttonSize;

	private GameObject theCamera1;
	private Vector2 pauseButtonPosition;

	// Use this for initialization
	void Start () {

		gamePause = false;
		theCamera1 = GameObject.Find("Main Camera");
	
	}
	
	// Update is called once per frame
	void Update () {
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;

		}
		if (fingerCount > 3)
		{
			print("User has " + fingerCount + " finger(s) touching the screen");
			gamePause = true;
		}

		if (Input.GetKeyDown ("space")) 
		{
			gamePause = true;
		}

		if (gamePause == true) 
		{
			Time.timeScale = 0.0f;
		}

		if (gamePause == false) 
		{
			Time.timeScale = 1.0f;
		}

		var cameraHalfWidth = theCamera1.GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);
		var cameraHalfHeight = theCamera1.GetComponent<Camera>().orthographicSize * ((float)Screen.height / Screen.width);
		pauseButtonPosition = new Vector2 (cameraHalfWidth, cameraHalfHeight);
	}

	void OnGUI(){
		if (GUI.Button (new Rect (pauseButtonPosition, buttonSize), "UnPause")) 
		{
			gamePause = false;
		}
	}
}
