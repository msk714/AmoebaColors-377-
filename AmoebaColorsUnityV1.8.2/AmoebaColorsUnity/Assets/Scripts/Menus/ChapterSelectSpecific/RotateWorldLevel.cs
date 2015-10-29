using UnityEngine;
using System.Collections;

public class RotateWorldLevel : MonoBehaviour {


	public GameObject target = null;
	public int speed;
	public float friction;
	public float lerpSpeed;
	private float xDeg;
	private float yDeg;
	private Quaternion fromRotation;
	private Quaternion toRotation;


	public float tapCheckTime = 0.75f;
	private float tapTimePassed = 0;

	bool hasGrabbedPoint = false;
	Vector3 grabbedPoint;

	void Update ()
	{





		if (Input.touchCount > 0) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch (0);


			
			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
			{
				updateTap();
				if (!hasGrabbedPoint)
				{
					hasGrabbedPoint = true;
					grabbedPoint = getTouchedPoint ();
				}
				else
				{
					Vector3 targetPoint = getTouchedPoint ();
					Quaternion rot = Quaternion.FromToRotation (grabbedPoint, targetPoint);
					transform.localRotation *= rot;
				}
			} else
				hasGrabbedPoint = false;


			if (touch.phase == TouchPhase.Began)
			{
				startTap();
			}
			if (touch.phase == TouchPhase.Ended)
			{
				if(endTap())
				{
					//Debug.Log ("Tap");
				}
			}



		}


/*
		//Touch Controls
		if (Input.touchCount > 0) {
			// The screen has been touched so store the touch
			Touch touch = Input.GetTouch (0);
			
			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
				if (!hasGrabbedPoint) {
					hasGrabbedPoint = true;
					grabbedPoint = getTouchedPoint ();
				} else {
					Vector3 targetPoint = getTouchedPoint ();
					Quaternion rot = Quaternion.FromToRotation (grabbedPoint, targetPoint);
					transform.localRotation *= rot;
				}
			} else
				hasGrabbedPoint = false;
		}
*/


			//Mouse Controls

			if (Input.GetMouseButton (0))
			{
			updateTap();
				if (!hasGrabbedPoint) {
					hasGrabbedPoint = true;
					grabbedPoint = getTouchedPoint ();
				} else {
					Vector3 targetPoint = getTouchedPoint ();
					Quaternion rot = Quaternion.FromToRotation (grabbedPoint, targetPoint);
					transform.localRotation *= rot;
				}
			} else
				hasGrabbedPoint = false;
			
		if (Input.GetMouseButtonDown (0))
		{
			startTap();
			//Debug.Log (tapTimePassed);
		}
		if (Input.GetMouseButtonUp (0))
		{
			if(endTap())
			{
				//Debug.Log ("Tap");
				getTouchedPoint();

			}
		}




	}


	Vector3 getTouchedPoint()
	{
		RaycastHit hit;
		Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
		
		return transform.InverseTransformPoint(hit.point);
	}




	void startTap()
	{
		tapTimePassed = 0;
		tapTimePassed = tapTimePassed + Time.deltaTime;
	}
	void updateTap()
	{
		tapTimePassed = tapTimePassed + Time.deltaTime;
	}
	
	bool endTap()		// return true if tap else it is a hold
	{
		if (tapTimePassed < tapCheckTime) {
			return true;
		} else
			return false;
	}
	

}