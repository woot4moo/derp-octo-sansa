using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

	GameObject[] players;
	KeyCode left = KeyCode.A;
	KeyCode right = KeyCode.D;
	KeyCode up = KeyCode.W;
	KeyCode down = KeyCode.S;
	Quaternion targetRotation = new Quaternion ();
	float forwardSpeed = 20.0f;
	float rotationSpeed = 1.5f;

	// Use this for initialization
	void Start ()
	{
		players = GameObject.FindGameObjectsWithTag ("Player"); 

	}
	
	// Update is called once per frame
	void Update ()
	{
		//Regular model movement
		Vector3 forwardVector = transform.forward * Time.deltaTime;
		transform.Translate (forwardVector * forwardSpeed);
		
		//controls for model
		if (Input.GetKey (left)) {
			transform.Translate (-transform.right * Time.deltaTime);
		} else if (Input.GetKey (right)) {
			transform.Translate (transform.right * Time.deltaTime);

		} else if (Input.GetKey (up)) {
			transform.Translate (transform.up * Time.deltaTime);

		} else if (Input.GetKey (down)) {
			transform.Translate (-transform.up * Time.deltaTime);
		}
	
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);	
		RaycastHit hit;
		Vector3 distance = Vector3.zero;
		if (Physics.Raycast (ray, out hit, 1200)) {
			Debug.DrawLine (ray.origin, hit.point);
			distance = hit.point - 
				transform.position;
			targetRotation = Quaternion.LookRotation (distance);
		}
		if ((distance).sqrMagnitude > 3) {
			transform.rotation = Quaternion.Slerp 
	(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
		}
	}
	

}

