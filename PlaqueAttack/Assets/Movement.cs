using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

	GameObject[] players;
	KeyCode left = KeyCode.A;
	KeyCode right = KeyCode.D;
	KeyCode up = KeyCode.W;
	KeyCode down = KeyCode.S;
	// Use this for initialization
	void Start ()
	{
		players = GameObject.FindGameObjectsWithTag ("Player"); 

	}
	
	// Update is called once per frame
	void Update ()
	{
		//Regular model movement
		Vector3 forwardSpeed = transform.forward * Time.deltaTime;
		transform.Translate (forwardSpeed);
		
		//controls for model
		if (Input.GetKey (left)) {
			transform.Translate (-transform.right * Time.deltaTime);
			Debug.Log ("Moving left");
		} else if (Input.GetKey (right)) {
			Debug.Log ("Moving right");
			transform.Translate (transform.right * Time.deltaTime);

		} else if (Input.GetKey (up)) {
			Debug.Log ("Moving up");
			transform.Translate (transform.up * Time.deltaTime);

		} else if (Input.GetKey (down)) {
			Debug.Log ("Moving down");
			transform.Translate (-transform.up * Time.deltaTime);
		}
	
		Debug.Log(Input.mousePosition);
	}
}

