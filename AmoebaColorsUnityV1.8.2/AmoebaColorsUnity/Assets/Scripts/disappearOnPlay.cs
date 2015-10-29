using UnityEngine;
using System.Collections;

public class disappearOnPlay : MonoBehaviour {

	private Renderer visible;
	
	void Start () {

		visible = GetComponent<Renderer>();
		visible.enabled = !visible.enabled;
	}

}
