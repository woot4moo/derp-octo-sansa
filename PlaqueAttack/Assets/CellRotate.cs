using UnityEngine;
using System.Collections;

public class CellRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAroundLocal(transform.up, 3 * Time.deltaTime);
	}
}
