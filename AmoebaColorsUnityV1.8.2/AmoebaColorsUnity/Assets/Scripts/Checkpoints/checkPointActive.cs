using UnityEngine;
using System.Collections;

public class checkPointActive : MonoBehaviour {

	public bool currentPoint;

	private SpriteRenderer mySprite;
	private GameObject me;
	private Color red;
	private Color green;


	void Start()
	{
		currentPoint = false;
		red = Color.red;
		green = Color.green;
		me = this.gameObject;
		mySprite = me.GetComponent<SpriteRenderer>();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			mySprite.color = green;
		}
	}
	
}
