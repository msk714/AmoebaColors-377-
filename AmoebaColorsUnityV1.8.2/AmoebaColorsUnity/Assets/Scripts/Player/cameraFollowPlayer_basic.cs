using UnityEngine;
using System.Collections;

public class cameraFollowPlayer_basic : MonoBehaviour {



	public Transform player;
	public float followSpeed = 2;
	public bool fixedCamera = false;

	private Vector3 endPos;
	private float cameraDistance = 10F;
	

	// Use this for initialization
	void Start () {

		cameraDistance = cameraDistance * -1;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	

		if (fixedCamera == false) {			//if false then the camera will lag behind the camera, else it will be completly fixed on the player

			endPos.x = player.transform.position.x;
			endPos.y = player.transform.position.y;
			endPos.z = player.transform.position.z + cameraDistance;

			transform.position = Vector3.Lerp (transform.position, endPos, (Time.smoothDeltaTime * followSpeed));
		}
		else 
		{
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z + cameraDistance);
		}
	}
}
