using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {
	void Update() {
		transform.Translate(Vector3.forward * Time.deltaTime);
		transform.Translate(Vector3.right * Time.deltaTime, Space.World);
	}
}
