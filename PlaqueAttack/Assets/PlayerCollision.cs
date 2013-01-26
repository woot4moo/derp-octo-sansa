using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	 void OnTriggerEnter(Collider other) {
		Debug.Log("Collision");
        Destroy(other.gameObject);
		
    }
}
