using UnityEngine;
using System.Collections;

public class backgroundScoll : MonoBehaviour {


	public float speed = 0;		//How fast should the background move relative to player
	public float idleDivisor = 1; //highnumber means background moves slower when not moving player
	private GameObject player;


	private float idleLocX;
	private float idleLocY;

	// Update is called once per frame
	void Update () {

		player = GameObject.Find("AveragePlayerFollow");
		if (player != null)
		{
			idleLocX = idleLocX + Time.deltaTime;
			idleLocY = idleLocY + Time.deltaTime;
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2 ((player.transform.position.x * speed) + (idleLocX * speed/idleDivisor) ,(player.transform.position.y * speed) +(idleLocX * speed/idleDivisor));
		}
	}
}
