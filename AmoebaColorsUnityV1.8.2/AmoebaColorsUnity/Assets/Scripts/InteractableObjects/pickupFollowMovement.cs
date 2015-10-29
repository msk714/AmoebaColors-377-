using UnityEngine;
using System.Collections;

public class pickupFollowMovement : MonoBehaviour {
	
	public bool isFollowing;
	public float magnetStrength;
	public bool hasBeenFollowing;
	public bool canAdd;

	private float stopDistance;
	private GameObject player;
	private Transform target;

	
	void Start () 
	{
		player = GameObject.Find("playerCell");
		isFollowing = false;
		hasBeenFollowing = false;
		canAdd = true;
	}

	void Update () 
	{
		if (player != null)
		{
			if (player.GetComponent<playerController>().dropObjects == true || player.GetComponent<playerController>().amoebaColor != 1)
			{
				isFollowing = false;
			}
			if(isFollowing == true)
			{
				if(Vector3.Distance (transform.position, target.position) >= stopDistance)
				{
					transform.position += (target.position - transform.position).normalized * magnetStrength * Time.deltaTime;
				}
			}
			if(isFollowing == false && hasBeenFollowing == true)
			{
				canAdd = true;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (other.gameObject.GetComponent<playerController>().amoebaColor == 1)
			{
				hasBeenFollowing = true;
				isFollowing = true;
				player = other.gameObject;
				target = player.transform;
				stopDistance = player.GetComponent<CircleCollider2D>().radius - (player.GetComponent<CircleCollider2D>().radius/2);

				other.gameObject.GetComponent<playerController>().numberOfKeys = 1;
			}
		}
	}
}
