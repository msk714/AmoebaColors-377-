using UnityEngine;
using System.Collections;

public class worldPortalChapter : MonoBehaviour {

	public string levelName;
	public int levelInt;

	public ParticleSystem ParticleOnClick;

	void start()
	{
		ParticleOnClick.startColor = gameObject.GetComponent<SpriteRenderer>().color;



	}


	public void playParticles()
	{
		Instantiate(ParticleOnClick, transform.position, Quaternion.identity);
		ParticleSystem tempParticles = GameObject.FindObjectOfType<ParticleSystem>();
		
		Debug.Log (tempParticles);
		DestroyObject(tempParticles.gameObject, 2.0f);
	}


}
