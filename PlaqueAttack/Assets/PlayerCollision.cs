using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{

	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Collision");
		Movement mvmt = (Movement)GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent ("Movement");
		mvmt.alive = false;
	}
	
}
