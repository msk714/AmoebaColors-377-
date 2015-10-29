using UnityEngine;
using System.Collections;

public class enemyPathMovement : MonoBehaviour {
	
	public GameObject[] enemyCheckPoint;
	private int howManyPoints;
	public float moveSpeed;
	
	public bool loopPath;
	
	private Transform currentPoint;
	private int checkPointIndex;
	private bool incrementing;
	
	void Start () 
	{
		howManyPoints = enemyCheckPoint.Length - 1;
		checkPointIndex = 0;
		currentPoint = enemyCheckPoint[0].transform;
		incrementing = true;
	}
	
	
	void Update () 
	{
		transform.position += (currentPoint.position - transform.position).normalized * moveSpeed * Time.deltaTime;
		float distance = Vector3.Distance(currentPoint.position, transform.position);
		if(distance<0.5)
		{
			if (!loopPath)
			{
				//Debug.Log ("Itriggered");
				if(checkPointIndex == howManyPoints)
				{
					incrementing = false;
				}
				if(checkPointIndex == 0)
				{
					incrementing = true;
				}
				if(incrementing == true)
				{
					checkPointIndex++;
				}
				if(incrementing == false)
				{
					checkPointIndex --;
				}
				
			}
			else
			{
				if(checkPointIndex == enemyCheckPoint.Length)
				{
					checkPointIndex = 0;
				}
				else checkPointIndex++;
			}
			currentPoint = enemyCheckPoint[checkPointIndex].transform;
			
			
		}
	}
	
}
