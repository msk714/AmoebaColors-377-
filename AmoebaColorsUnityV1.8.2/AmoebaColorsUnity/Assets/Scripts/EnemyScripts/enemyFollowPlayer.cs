using UnityEngine;
using System.Collections;

public class enemyFollowPlayer : MonoBehaviour {

	public Vector3 startPos;
	public float maxMoveSpeed;
	public float minMoveSpeed;
	public float speedChangeRate;
	public float maxDist;
	private Rigidbody2D myRigidBody;
	
	private float nearStart;
	public float moveSpeed;
	private Transform target;
	private Vector3 direction;
	
	void Start () 
	{
		startPos = transform.position;
		target = GameObject.Find("playerCell").transform;
		moveSpeed = minMoveSpeed;
		nearStart = 0.5f;
		myRigidBody = GetComponent<Rigidbody2D>();
	}

	void Update () 
	{  
		if (target != null)
		{

			if (Vector3.Distance (startPos, target.position) <= maxDist) 
			{
				Vector3 dir = target.position - transform.position;
				dir.z = 0.0f; // Only needed if objects don't share 'z' value.
				if (dir != Vector3.zero) //Move Towards Target
				{
					
					direction = (target.position - transform.position).normalized * moveSpeed;
					myRigidBody.velocity = direction;
					//Debug.Log((target.position - transform.position).normalized * moveSpeed);
					//transform.position += (target.position - transform.position).normalized * moveSpeed * Time.deltaTime;
					if(moveSpeed < maxMoveSpeed)
					{
						moveSpeed += speedChangeRate;
					}
				}
			}
			if (Vector3.Distance (startPos, target.position) > maxDist)
			{
				if(Vector3.Distance (startPos, transform.position) > nearStart)
				{
					direction = (startPos - transform.position).normalized * moveSpeed;
					myRigidBody.velocity = direction;
					//transform.position += (startPos - transform.position).normalized * moveSpeed * Time.deltaTime;
					if(moveSpeed > minMoveSpeed)
					{
						moveSpeed -= speedChangeRate;
					}
				}
				else
				{
					moveSpeed = minMoveSpeed;
					myRigidBody.velocity = Vector3.zero;
				}

			}
			//GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		}
	}
}
