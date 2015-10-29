using UnityEngine;
using System.Collections;

public class playerMovement_keyboard : MonoBehaviour {



	public float moveSpeed = 0.05f;			//0-.2
	public int playerSize = 1;

	private float spdMultiplier = 2;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKey("w")) transform.Translate(Vector3.up * moveSpeed /(playerSize/spdMultiplier), Space.World);
		if(Input.GetKey("s")) transform.Translate(Vector3.down * moveSpeed /(playerSize/spdMultiplier), Space.World);
		if(Input.GetKey("a")) transform.Translate(Vector3.left * moveSpeed /(playerSize/spdMultiplier), Space.World);
		if(Input.GetKey("d")) transform.Translate(Vector3.right * moveSpeed /(playerSize/spdMultiplier), Space.World);
	}
}
