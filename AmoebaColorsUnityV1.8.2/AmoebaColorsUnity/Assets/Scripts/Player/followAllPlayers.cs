using UnityEngine;
using System.Collections;

public class followAllPlayers : MonoBehaviour {


	public GameObject[] playerInstances = {};

	private Vector3 myLocation;

	// Use this for initialization
	void Start () {
	
		playerInstances = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	

		playerInstances = GameObject.FindGameObjectsWithTag ("Player");

		if (playerInstances.Length > 0)
		{

			myLocation = new Vector3 (0, 0, 0);
			for (int count = 0; count < playerInstances.Length; count++)
			{
				//GameObject tempRef = playerInstances[count];
				myLocation += playerInstances [count].transform.position;
			}
			myLocation = myLocation / playerInstances.Length;

			transform.position = Vector3.Lerp (transform.position, myLocation, (Time.deltaTime * 2));
		}

	}
}
