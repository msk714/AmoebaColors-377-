using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Linq;

public class scr_worldController : MonoBehaviour {

	
	public float tapCheckTime = 0.75f;
	private float tapTimePassed = 0;


	public string selectedLevel;


	public GameObject[] uiObjs = {};  
	public Text levelText;
	

	void Update()
	{



		//Mouse Controls
		if (Input.GetMouseButtonDown (0))
		{
			StartTap();
		}
		if (Input.GetMouseButton (0))
		{
			UpdateTap();
		}
		if (Input.GetMouseButtonUp (0))
		{
			if(EndTap())		//if it is just a tap
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit))
				{
					if (hit.collider)
					{	
						if (hit.collider.gameObject.CompareTag("UIChapterPortal"))
						{
							worldPortalChapter chapSelect = hit.collider.gameObject.GetComponent<worldPortalChapter>();
							selectedLevel = chapSelect.levelName;
							ShowUIObjs();
							UpdateLevelText();
							chapSelect.playParticles();
						}
					}
				}
			}
			else HideUIObjs();
		}



		//Touch Controls
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch (0);
			
			if (touch.phase == TouchPhase.Began)
			{
				StartTap();
			}
			if (touch.phase == TouchPhase.Stationary)
			{
				UpdateTap();
			}
			if (touch.phase == TouchPhase.Ended)
			{
				if(EndTap())		//if it is just a tap
				{
					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					if (Physics.Raycast (ray, out hit))
					{
						if (hit.collider)
						{	
							if (hit.collider.gameObject.CompareTag("UIChapterPortal"))
							{
								worldPortalChapter chapSelect = hit.collider.gameObject.GetComponent<worldPortalChapter>();
								selectedLevel = chapSelect.levelName;
								ShowUIObjs();
								UpdateLevelText();
								chapSelect.playParticles();
							}
						}
					}
				}
				else HideUIObjs();
			}
		}
	}

	
	void StartTap()
	{
		tapTimePassed = 0;
		tapTimePassed = tapTimePassed + Time.deltaTime;
	}
	void UpdateTap()	//We should use this WHILEthe button is down to update the time
	{
		tapTimePassed = tapTimePassed + Time.deltaTime;
	}
	
	bool EndTap()		// return true if tap else it is a hold
	{
		if (tapTimePassed < tapCheckTime) {
			return true;
		} else
			return false;
	}

	public void goToLevel()
	{
		Application.LoadLevel (selectedLevel);
	}

	public void ShowUIObjs()
	{
		for (int count = 0; count<uiObjs.Length; count++)
		{
			GameObject tempUIobj = uiObjs[count];
			tempUIobj.gameObject.SetActiveRecursively(true);
		}
	}
	public void HideUIObjs()
	{
		for (int count = 0; count<uiObjs.Length; count++)
		{
			GameObject tempUIobj = uiObjs[count];
			tempUIobj.gameObject.SetActiveRecursively(false);
		}
	}
	
	public void UpdateLevelText()
	{
		scr_UIChaperSelect chapterRef = levelText.GetComponent<scr_UIChaperSelect> ();
		chapterRef.SetAsLevelText();
	}

}
