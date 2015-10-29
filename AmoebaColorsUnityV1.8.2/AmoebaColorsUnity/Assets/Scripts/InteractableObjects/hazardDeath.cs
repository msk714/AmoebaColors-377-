using UnityEngine;
using System.Collections;

public class hazardDeath : MonoBehaviour {


	public int levelNumber;
	public string levelName;

	public void NextLevel(int index)
	{
		Application.LoadLevel(index);
	}
	
	public void NextLevel(string levelName)
	{
		Application.LoadLevel(levelName);
	}



	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			Destroy(other.gameObject);

			NextLevel(levelNumber);
			NextLevel(levelName);
		}

	}
}
