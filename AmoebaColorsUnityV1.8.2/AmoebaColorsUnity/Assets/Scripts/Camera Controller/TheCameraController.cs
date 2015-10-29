using UnityEngine;
using System.Collections;

public class TheCameraController : MonoBehaviour 
{
	private GameObject Player;
	public Vector2 Margin, Smoothing;
	public float smoothRateY = 0.5f;
	public float smoothRateX = 0.5f;
	private BoxCollider2D _Bounds;
	public bool IsFollowing { get; set; }
	private Vector3 _min, _max;
	private Vector2 velocity;
	

	public void Start()
	{
		_Bounds = GameObject.Find("Camera Bounds").GetComponent<BoxCollider2D>();
		Player = GameObject.Find ("playerCell");
		_min = _Bounds.bounds.min;
		_max = _Bounds.bounds.max;
		IsFollowing = true;
		velocity = new Vector2(0.5f, 0.5f);

	}
	
	public void Update()
	{
		var x = transform.position.x;
		var y = transform.position.y;
		if (Player != null)
		{
			if (IsFollowing) 
			{
				if (Mathf.Abs (x - Player.GetComponent<Rigidbody2D>().position.x) > Margin.x)
					x = Mathf.SmoothDamp (x, Player.GetComponent<Rigidbody2D>().position.x, ref velocity.x, smoothRateX);
				if (Mathf.Abs (y - Player.GetComponent<Rigidbody2D>().position.y) > Margin.y)
					y = Mathf.SmoothDamp (y, Player.GetComponent<Rigidbody2D>().position.y, ref velocity.y, smoothRateY);
			}
		}
		var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);
		
		x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		y = Mathf.Clamp (y, _min.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize);
		
		Vector3 newPos = new Vector3 (x, y, transform.position.z);
		transform.position = Vector3.Slerp (transform.position, newPos, Time.time);
	}
	
}