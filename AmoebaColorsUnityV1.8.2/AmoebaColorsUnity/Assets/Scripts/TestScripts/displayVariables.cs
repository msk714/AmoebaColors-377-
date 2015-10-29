using UnityEngine;
using System.Collections;

public class displayVariables : MonoBehaviour {

	private GameObject player;
	private bool pCanLaunch;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("playerCell");
		//pCanLaunch = player.GetComponent<canLaunch>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
