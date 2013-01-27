using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	GameObject plaque;
	Vector3 offset = new Vector3(0, 7, -20);	
	
	void Start ()
	{
		plaque = GameObject.FindGameObjectWithTag("Player");
	}
	
	void LateUpdate() 
	{
		
		transform.position = Vector3.Slerp(transform.position, plaque.transform.position + transform.rotation * offset, 10 * Time.deltaTime);
		//transform.LookAt(plaque.transform.position);
	}
}

