using UnityEngine;
using System.Collections;

public class hitPlayerJumpToStart : MonoBehaviour {
	

	void OnCollisionEnter2D (Collision2D other){


		if(other.gameObject.CompareTag("Player"))
		{
			transform.position = this.gameObject.GetComponent<enemyFollowPlayer>().startPos;
		}
	}
}
