using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

	KeyCode left = KeyCode.A;
	KeyCode right = KeyCode.D;
	KeyCode up = KeyCode.W;
	KeyCode down = KeyCode.S;
	public float forwardSpeed = 10.0f;
	public float turnSpeed = 1.0f;
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
			Vector3 forwardVector = Vector3.forward * Time.deltaTime;
			transform.Translate (forwardVector * forwardSpeed);
			
			if (Input.GetKey(left)) {
				transform.RotateAroundLocal(transform.forward, Time.deltaTime * turnSpeed);	
				Camera.mainCamera.transform.RotateAround(transform.forward, Time.deltaTime * turnSpeed);
			}
			if (Input.GetKey(right)) {
				transform.RotateAroundLocal(transform.forward, -Time.deltaTime * turnSpeed);	
				Camera.mainCamera.transform.RotateAround(transform.forward, -Time.deltaTime * turnSpeed);
			}
			if (Input.GetKey (up)) {
				transform.RotateAroundLocal(transform.right, -Time.deltaTime * turnSpeed);
				Camera.mainCamera.transform.RotateAround(Camera.mainCamera.transform.right, -Time.deltaTime * turnSpeed);
			} 
			if (Input.GetKey (down)) {
				transform.RotateAroundLocal(transform.right, Time.deltaTime * turnSpeed);
				Camera.mainCamera.transform.RotateAround(Camera.mainCamera.transform.right, Time.deltaTime * turnSpeed);
			}
		
		}
	}
	


	
}

