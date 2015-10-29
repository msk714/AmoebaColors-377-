using UnityEngine;
using System.Collections;

public class rotateObject : MonoBehaviour {


	public float rotSpeed = 10f;
	
	// Update is called once per frame
	void Update () {
	

		transform.Rotate (0,0,rotSpeed*Time.deltaTime);

	}
}
