using UnityEngine;
using System.Collections;

public class ParticleFollow : MonoBehaviour {

	GameObject plaque;
	Vector3 offset = new Vector3(0, 0, -35);	
	
	void Start ()
	{
		plaque = GameObject.FindGameObjectWithTag("Player");
	}
	
	void LateUpdate() 
	{
		
		transform.position = plaque.transform.position + transform.rotation * offset;
		transform.LookAt(plaque.transform.position);
	}
}
