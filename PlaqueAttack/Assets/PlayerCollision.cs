using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
	
	private Movement mvmt;
	private Rigidbody body;
	
	public float force = 0.5f;
	
	void Start() {
		mvmt = (Movement)gameObject.GetComponent ("Movement");
		body = gameObject.rigidbody;
	}
	
	void Update() {
		Debug.Log(body.velocity);
		body.transform.position += body.velocity * Time.deltaTime;	
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag.Equals("Pulsing") || other.tag.Equals("Stopper")) {
			mvmt.alive = false;
		} else if (other.tag.Equals("Pusher")) {
			body.velocity += other.transform.forward * force;
		} else if (other.tag.Equals("Destroyer")) {
			mvmt.alive = false;
			gameObject.SetActive(false);
		}
	}
	
}
