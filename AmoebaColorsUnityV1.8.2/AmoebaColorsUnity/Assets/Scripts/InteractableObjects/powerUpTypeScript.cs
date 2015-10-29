using UnityEngine;
using System.Collections;

public class powerUpTypeScript : MonoBehaviour {

	// Use this for initialization
	public int powerUpType = 1;	//1 is blue


	public ParticleSystem particleCollider;
	


	public void playParticle()
	{
	
		Instantiate(particleCollider, transform.position, Quaternion.identity);
		GameObject tempParticles = GameObject.FindGameObjectWithTag("PowerupParticle");

		Debug.Log (tempParticles);
		DestroyObject(tempParticles, 2.0f);

	}

}