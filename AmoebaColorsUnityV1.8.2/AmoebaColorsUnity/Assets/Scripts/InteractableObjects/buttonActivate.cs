using UnityEngine;
using System.Collections;

public class buttonActivate : MonoBehaviour {


	public int countNeeded;
	private int currentCount;

	public GameObject linkedButton;
	private buttonActivate linkedScriptRef;
	private bool isLinked = false;
	private bool beenActivated = false;


	public GameObject[] objsToSpawn = {};
	public GameObject[] objsToDespawn = {};

	
	void SpawnThese()
	{
		if (objsToSpawn.Length > 0)
			for (int count =0; count< objsToSpawn.Length; count++)
			{
				objsToSpawn[count].SetActiveRecursively(true);
			}
	}
	void DespawnThese()
	{
		if (objsToDespawn.Length > 0)
			for (int count =0; count< objsToSpawn.Length; count++)
		{
			objsToDespawn[count].SetActiveRecursively(false);
		}
	}





	// Use this for initialization
	void Start ()
	{

		if (linkedButton != null)
		{
			linkedScriptRef = linkedButton.GetComponent<buttonActivate>();
			isLinked = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isLinked)
		{
			if (linkedScriptRef.currentCount >= linkedScriptRef.countNeeded)
			{
				if ((currentCount >= countNeeded) && (beenActivated == false))
				{
					beenActivated = true;
					SpawnThese();
					DespawnThese();
				}
			}
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player")) {
			currentCount++;
			Debug.Log ("Increase Count: "+ currentCount);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			currentCount--;
			Debug.Log ("Decrease Count: " + currentCount);
		}
	}

}
