using UnityEngine;
using System.Collections;

public class gameTimerScript : MonoBehaviour {


	public bool timerOn = true;

	private float timeCur;
	private float timeStart = 0f;
	private float savedTime = 0f;

	private string savedLevel;


	//-----------------------------FUNCTIONS!!!!-----------
	public void addTime()
	{
		timeCur += Time.deltaTime;
		savedTime = timeCur;		//save the time for when the level is finished
	}
	public void restartTimer()
	{
		timeCur = 0f;
	}
	public void stopTimer()
	{
		timerOn = false;
		savedTime = timeCur;
	}
	public void saveTime()
	{
		savedTime = timeCur;
	}
	public float getSavedTime()
	{
		return savedTime;
	}
	public string displayTime()
	{
		string minutes = Mathf.Floor(getSavedTime() / 60).ToString("00");
		string seconds = (getSavedTime() % 60).ToString("00");
		return minutes + ":" + seconds;
	}
	public string getLastlevel()
	{
		return savedLevel;
	}

	//-----------------------------FUNCTIONS!!!!---------



	void Awake ()
	{
		DontDestroyOnLoad(gameObject);		//we need to save the time across levels (like for a high schore screen)
	}

	
	// Use this for initialization
	void Start () {

		timeCur = timeStart;
		savedLevel = Application.loadedLevelName;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (timerOn == true)
		{
			addTime();

			//Debug.Log (timeCur);
		}
		else
		{
			timerOn = false;
			saveTime ();
		}
	}

}

