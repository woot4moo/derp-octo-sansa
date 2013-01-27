using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

	KeyCode left = KeyCode.A;
	KeyCode right = KeyCode.D;
	KeyCode up = KeyCode.W;
	KeyCode down = KeyCode.S;
	Quaternion targetRotation = new Quaternion ();
	public float forwardSpeed = 10.0f;
	float rotationSpeed = 1.5f;
	//public  bool isAlive = true;
	
	    public bool alive {get; set;} 

	// Use this for initialization
	void Start ()
	{
		alive=true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (alive) {
		
		
			//Regular model movement
			Vector3 forwardVector = transform.forward * Time.deltaTime;
			//Debug.Log ("Vector: " + forwardVector);
			transform.Translate (forwardVector * forwardSpeed);
		
			//controls for model
			if (Input.GetKey (left)) {
				transform.Translate (-transform.right * Time.deltaTime * forwardSpeed);
			} else if (Input.GetKey (right)) {
				transform.Translate (transform.right * Time.deltaTime * forwardSpeed);

			} else if (Input.GetKey (up)) {
				transform.Translate (transform.up * Time.deltaTime * forwardSpeed);

			} else if (Input.GetKey (down)) {
				transform.Translate (-transform.up * Time.deltaTime * forwardSpeed);
			}
	
			//Debug.Log ("Forward: " + transform.forward);
			transform.RotateAroundLocal(transform.up, Input.GetAxis ("Mouse X") * 0.2f);
			transform.RotateAroundLocal(transform.right, -Input.GetAxis ("Mouse Y") * 0.2f);
			/*Vector3 viewMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			
			if (viewMousePos.x < 0.4) {
				if (viewMousePos.x < Mathf.Epsilon) {
					transform.RotateAroundLocal(transform.right, -10 * Time.deltaTime);	
				} else {
					transform.RotateAroundLocal(transform.right, Mathf.Clamp(-1/viewMousePos.x, -1, -10) * Time.deltaTime);	
				}
			} else if (viewMousePos.x > 0.6) {
				if (viewMousePos.x > 1 - Mathf.Epsilon) {
					transform.RotateAroundLocal(transform.right, 10 * Time.deltaTime);	
				} else {
					transform.RotateAroundLocal(transform.right, -Mathf.Clamp(1/(1 - viewMousePos.x), 1, 10) * Time.deltaTime);	
				}
			}
			
			if (viewMousePos.y < 0.4) {
				if (viewMousePos.y < Mathf.Epsilon) {
					transform.RotateAroundLocal(transform.up, 10 * Time.deltaTime);	
				} else {
					transform.RotateAroundLocal(transform.up, Mathf.Clamp(1/viewMousePos.x, 1, 10) * Time.deltaTime);	
				}
			} else if (viewMousePos.y > 0.6) {
				if (viewMousePos.y > 1 - Mathf.Epsilon) {
					transform.RotateAroundLocal(transform.up, -10 * Time.deltaTime);	
				} else {
					transform.RotateAroundLocal(transform.up, Mathf.Clamp(-1/(1 - viewMousePos.x), -1, -10) * Time.deltaTime);	
				}
			}*/
			/*
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
			}*/
		}
	}
	


	
}

