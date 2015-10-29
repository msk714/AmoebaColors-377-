using UnityEngine;
using System.Collections;

public class particleLifetimeTimer : MonoBehaviour {


	public void particleTimerStart( float Timer)
	{

		StartCoroutine(particleDestroyTimer(Timer));
	}

public IEnumerator particleDestroyTimer(float timer)
	{
		yield return new WaitForSeconds(timer);
		DestroyImmediate(this.gameObject);
	}
}
