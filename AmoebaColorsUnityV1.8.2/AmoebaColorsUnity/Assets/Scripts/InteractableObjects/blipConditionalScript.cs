using UnityEngine;
using System.Collections;

public class blipConditionalScript : MonoBehaviour {

	public GameObject player;
	public GameObject[] blipObjects = {};
	public float minDistance = 2.0f;

	private int blipIndex;


void Start(){

		blipIndex = 0;
		Vector2 blipPosition = blipObjects[blipIndex].transform.position;
		this.transform.position = blipPosition;

	}

 void Update(){

		if (player != null)
		{
			if (DistanceToBlip(blipObjects[blipIndex]) <= minDistance)
			{
				blipIndex++;
				if (blipIndex < blipObjects.Length)
				{
					Vector2 blipPosition = blipObjects[blipIndex].transform.position;
					this.transform.position = blipPosition;
				}
				else 
				{
					this.gameObject.SetActiveRecursively(false);

				}
			}
		}



	}


	public float DistanceToBlip(GameObject blip)
	{
		float distance;
		distance = Vector2.Distance(blip.transform.position, player.transform.position);
		return distance;
	}
}