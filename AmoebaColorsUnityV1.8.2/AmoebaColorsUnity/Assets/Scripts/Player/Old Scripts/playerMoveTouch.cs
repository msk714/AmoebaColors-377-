using UnityEngine;
using System.Collections;

public class playerMoveTouch : MonoBehaviour {

	public float baseSpeed = 1; //1 is normal speed
	public int playerSize = 1;	//A player Size 1 is the smallest possible size
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void Update () {
		if (Input.touchCount > 0) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch(0);
			
			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
				// If the finger is on the screen, move the object smoothly to the touch position
				//Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));                
				//transform.position = Vector3.Lerp(transform.position, touchPosition, (Time.deltaTime*baseSpeed)/playerSize);
			}
		}
	}
	
}
