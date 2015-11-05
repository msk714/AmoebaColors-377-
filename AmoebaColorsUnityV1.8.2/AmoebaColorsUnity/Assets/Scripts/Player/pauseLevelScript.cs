using UnityEngine;
using System.Collections;

public class pauseLevelScript : MonoBehaviour {

	public bool gamePause;

	// Use this for initialization
	void Start () {

		gamePause = false;
	
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
	}
}
