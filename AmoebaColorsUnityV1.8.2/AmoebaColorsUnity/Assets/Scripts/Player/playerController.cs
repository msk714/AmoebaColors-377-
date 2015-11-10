using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour {




	//THIS IS A COMMENT. Hi.


	public float baseSpeed = 0.1f; //.1 is normal speed the player can move
	public float playerSize = 1.0f;	//A player Size 1 is the smallest possible size
	public bool hasKey = false; //checks if you have a key
	public Vector2 startPos;
	public int numberOfKeys;
	public bool dropObjects;
	public bool startRespawnTimer;
	public float respawnTimer = 1.0f;
	private float myDepth;
	private Vector3 myTransform;

	private List<GameObject> keyArray;

	//Merged Variables
	private Vector2 mousePosition2D;
	private Vector3 mousePosition3D;
	private Vector3 touchPosition3D;
	
	//Magnetic Forces
	public bool reverseMag = false;
	public float magForceMultiplier = 1.0f;
	private float magneticForce;
	public float magneticDistance = 4;			// the distance at which the pointer must be to affect an instance of the player

	//Health System
	private Sprite currentSprite;
	private bool beenHit = false;
	private bool playerInvuln;
	private float knockBackMultiplier = 100.0f;
	private Vector3 startSize;


	private GameObject checkpointCheck;
	private GameObject currentCheckpoint;

	private Animation playerAnimation;
	private string displayText;

	private Vector3 touchPosition;
	private Vector3 reverseTouchPosition;
	private float playerSpeed;
	private int touchCount= 0;
	public bool canLaunch;


	public bool usingTouch = true;		//false if you want to use keyboard

	private string currentPickup = "none";

	public int amoebaColor = 0;		// 0  is neutral (grey), 1 is blue, 2 is yellow



	public void changeToBlue()
	{
		renderer.sprite = cellBlue;
		amoebaColor = 1;

		//Debug.Log ("Now BLUE Amoeba!");
	}
	public void changeToYellow()
	{
		renderer.sprite = cellYellow;
		amoebaColor = 2;
		
		//Debug.Log ("Now YELLOW Amoeba!");
	}
	public void changeToGreen()
	{
		renderer.sprite = cellGreen;
		amoebaColor = 3;
		
		Debug.Log ("Now GREEN Amoeba!");
	}

	public void calculateAmeobaSize()			//use to set the scale of the amoeba
	{
		float number = playerSize*0.25f;

		transform.localScale =  new Vector3 (number, number, number);
	}


	//IEnumerators Start


	public IEnumerator Knockback(float knockDur, float knockbakcPwr, Vector3 knockbackDir, Rigidbody2D knockBody)
	{
		float timer = 0;

		while( knockDur > timer)
		{
			timer +=Time.deltaTime;

			knockBody.AddForce(new Vector3(knockbackDir.x * knockbakcPwr, knockbackDir.y * knockbakcPwr, transform.position.z));
		}

		yield return 0;
	}

	public IEnumerator changePlayerInvuln(float timer)
	{
		bool invuln = false;

		
		yield return new WaitForSeconds(timer);
		gameObject.GetComponent<playerController>().playerInvuln = invuln;
		Debug.Log ("changePlayerInvuln = false");
	}

	public IEnumerator changeBeenHit(float timer)
	{
		bool hit = false;

		yield return new WaitForSeconds(timer);
		gameObject.GetComponent<playerController>().beenHit = hit;
	}

	public void checkHitStatus()
	{
		if(beenHit)
		{
			transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z);
			StartCoroutine(changeBeenHit(1f));			//was 6 seconds?????
		}
		else
		{
			transform.localScale = startSize;
		}
	}



	private IEnumerator PlayAnimationInterval(int n, float time)
	{
		while (n > 0)
		{
			playerAnimation.Play("player_whiteFlash");
			--n;
			yield return new WaitForSeconds(time);
		}
	}

	// IEnumerators End

	void RepelPlayer (bool touchInput)		//if touch == true use touch input
	{
		
		if (touchInput == true) {
			Touch touch = Input.GetTouch (0);
			
			Vector3 touchPosition3D = Camera.main.ScreenToWorldPoint (new Vector3(touch.position.x, touch.position.y, 10));  
			
			if ((Vector3.Distance (touchPosition3D, transform.position)) < magneticDistance) {
				Vector3 dir = touchPosition3D - transform.position;
				dir = dir.normalized;
				
				magneticForce = magneticDistance / (Vector3.Distance (touchPosition3D, transform.position));
				
				GetComponent<Rigidbody2D> ().AddForce (-dir * magneticForce * magForceMultiplier);
			}
		}
		else
		{
			//NOT using touch
			
			if ((Vector3.Distance (mousePosition3D, transform.position)) < magneticDistance) {
				Vector3 dir = mousePosition3D - transform.position;
				dir = dir.normalized;
				
				magneticForce = magneticDistance / (Vector3.Distance (mousePosition3D, transform.position));
				
				GetComponent<Rigidbody2D> ().AddForce (-dir * magneticForce * magForceMultiplier);
			}
		}
	}

	//Set up all of our sprite vars and update them in the Start function
	SpriteRenderer renderer;
	Rigidbody2D myRigidbody;
	Sprite cellGrey;
	Sprite cellBlue;
	Sprite cellGreen;
	Sprite cellYellow;

	void Start()
	{
		cellGrey = Resources.Load<Sprite>("Art/Sprites/spr_cell_grey");
		cellBlue = Resources.Load<Sprite>("Art/Sprites/spr_cell_blue");
		cellGreen = Resources.Load<Sprite>("Art/Sprites/spr_cell_green");
		cellYellow = Resources.Load<Sprite>("Art/Sprites/spr_cell_yellow");
		renderer = GetComponent<SpriteRenderer>();
		myRigidbody = GetComponent<Rigidbody2D>();
		startPos = transform.position;
		playerAnimation = GetComponent<Animation>();
		startSize = transform.localScale;

	}

	void FixedUpdate(){

		myTransform = transform.position;
		myTransform.z = 0;
		transform.position = myTransform;
		
		//--------CONTROLS-------------------------------
		
		if (usingTouch == false)
		{
			
			if (Input.GetKey ("w"))
				transform.Translate (Vector3.up * baseSpeed, Space.World);
			if (Input.GetKey ("s"))
				transform.Translate (Vector3.down * baseSpeed, Space.World);
			if (Input.GetKey ("a"))
				transform.Translate (Vector3.left * baseSpeed, Space.World);
			if (Input.GetKey ("d"))
				transform.Translate (Vector3.right * baseSpeed, Space.World);
			
			if (Input.GetKey ("p"))
				Debug.Log(amoebaColor);

			if (Input.GetMouseButton(0))
			{
				mousePosition3D = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));  
				mousePosition2D = new Vector2(Input.mousePosition.x, Input.mousePosition.y); 
				if (reverseMag  == false)
				{
					transform.position = Vector3.Lerp(transform.position, mousePosition3D, (Time.deltaTime*baseSpeed*5)/playerSize);
				}
				else
				{
					RepelPlayer(usingTouch);
				}
			}

		} 
		else
		{
			
			if (Input.touchCount > 0)
			{
				// The screen has been touched so store the touch
				Touch touch1 = Input.GetTouch (0);

				if (amoebaColor == 2)
				{
					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay(touch1.deltaPosition);
					if (Physics.Raycast(ray, out hit))
						if (hit.collider != null)
							if (hit.collider.gameObject.tag == "Player")
							{
								Debug.Log ("Yayyy");
							}
					}


				if (touch1.phase == TouchPhase.Stationary || touch1.phase == TouchPhase.Moved)
				{
					// If the finger is on the screen, move the object smoothly to the touch position
					touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch1.position.x, touch1.position.y, 10));  
					//reverseTouchPosition = new Vector3 (-touchPosition.x, -touchPosition.y, 10);
						Vector3 direction = (touchPosition - transform.position).normalized * baseSpeed * Time.smoothDeltaTime * 2200;
						myRigidbody.velocity = direction;		

				}
				else
				{
					RepelPlayer(usingTouch);
				}
			}
			else
			{
				myRigidbody.velocity = Vector3.zero;
			}
			if (Input.touchCount > 3)
			{
				Application.LoadLevel(0);
			}
		}
	}

	void Update () {

		touchCount = 0;

		foreach (Touch touch in Input.touches) //Tracks how many fingers touching
		{
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
			{
				touchCount++;
			}
		}

		if ((touchCount == 2) && (canLaunch == true))
		{
			canLaunch = false;
			//changeToYellow();
		}

		if (touchCount < 3)
		{
			//changeToBlue();
			canLaunch = true;
		}
		//------end CONTROLS----------


		//Debug.Log (playerSpeed);
		calculateAmeobaSize();

		if (startRespawnTimer = true)
		{
			respawnTimer -= Time.deltaTime;
			if (respawnTimer <= 0.0f)
			{
				RespawnTimerEnd();
			}
		}

		//Checking if hit to change size
		checkHitStatus();


	}	//end update function

	void RespawnTimerEnd()
	{
		dropObjects = false;
		startRespawnTimer = false;
		respawnTimer = 1.0f;
	}

	//---------------PICK UPS & COLLISIONS-------------------------


	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("Power Up"))
		{
			powerUpTypeScript powerUpRef = other.gameObject.GetComponent<powerUpTypeScript>();

			powerUpRef.playParticle();

			if (powerUpRef.powerUpType == 1)
			{
				changeToBlue();
			
				other.gameObject.SetActiveRecursively (false);
			}
			else
			{
				hasKey = false;
				numberOfKeys = 0;
			}
			if (powerUpRef.powerUpType == 2)
			{
				changeToYellow();
				
				other.gameObject.SetActiveRecursively (false);
			}
			if (powerUpRef.powerUpType == 3)
			{
				changeToGreen();
				
				other.gameObject.SetActiveRecursively (false);
			}

		}

		if (other.gameObject.CompareTag ("Pick Up"))
		{			
			if (amoebaColor == 1)	//we can only pick stuff up if we are blue(1)
			{
				currentPickup = other.gameObject.GetComponent<pickupHolderScript>().pickupName;
				//currentPickup = pickupNameRef.pickupName;							//store the pickups name in a string

				//keyArray.Add(other.gameObject);

				if(other.gameObject.GetComponent<pickupFollowMovement>().canAdd == true)
					{
						numberOfKeys ++;
						Debug.Log (numberOfKeys);
						other.gameObject.GetComponent<pickupFollowMovement>().canAdd = false;

					}
					if(other.gameObject.GetComponent<pickupFollowMovement>().isFollowing == true)
					{						
						hasKey = true;
					}
				Debug.Log ("Now holding: " + currentPickup);
			}
		}

		if (other.gameObject.CompareTag ("Door"))
		{
			doorLockedScript doorRef = other.gameObject.GetComponent<doorLockedScript>();


			//int tempKey = keyArray.Count;
			Debug.Log (numberOfKeys);
			//keyArray.RemoveAt(tempKey);
			 

			if (numberOfKeys > 0)
			{
				other.gameObject.SetActive (false);


			}
		}
		if (other.gameObject.CompareTag ("Destructable"))
		{
			if(amoebaColor == 2) //Player is yellow
			{
				other.gameObject.SetActiveRecursively (false);
			}
		}
		if (other.gameObject.CompareTag ("Dangerous"))
		{

			if (!playerInvuln)
			{
				if (!beenHit) 
				{
					Vector3 dir = other.gameObject.transform.position - transform.position;
					dir = dir.normalized;

					StartCoroutine(Knockback(0.02f, knockBackMultiplier, transform.position, myRigidbody));
					beenHit = true;
					playerInvuln = true;
					StartCoroutine(changePlayerInvuln(0.1f));   //was 50 seconds???   
				}
				else
				{
					numberOfKeys = 0;
					dropObjects = true;
					beenHit = false;

					if (currentCheckpoint == null)
					{
						startRespawnTimer = true;
						transform.position = startPos;
					}
					else
					{
						startRespawnTimer = true;
						transform.position = currentCheckpoint.transform.position;
					}
				}
			}
		}
		if (other.gameObject.CompareTag ("PlayerCheckpoint"))
		{
			checkpointCheck = other.gameObject;
			if (checkpointCheck.GetComponent<checkPointActive>().currentPoint == false)
			{
				currentCheckpoint = checkpointCheck;
				currentCheckpoint.GetComponent<checkPointActive>().currentPoint = true;
			}
		}
		
	}
}
