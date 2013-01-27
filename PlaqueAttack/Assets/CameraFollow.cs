using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	GameObject plaque;
		
	void Start ()
	{
		plaque = GameObject.Find("plaque");
	}
	
	void Update() 
	{
		
		transform.position = plaque.transform.position + transform.up * 4;// - (plaque.transform.position - transform.position).normalized * 10;
		transform.LookAt(plaque.transform.position);
	}
}

