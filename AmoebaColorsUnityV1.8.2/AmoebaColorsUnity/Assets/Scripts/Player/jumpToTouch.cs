using UnityEngine;
using System.Collections;

public class jumpToTouch : MonoBehaviour {

	private Vector3 touchPosition;
	
	void Update () {
		if (Input.touchCount > 0)
		{
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch (0);
			
			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
			{
				touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));  
				transform.position = touchPosition;
			}
		}
	}
}
