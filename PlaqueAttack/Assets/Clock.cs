using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{

	private float startTime;
	private float elapsedTime;
	public int beats = 5;
	private int beatSpeed = 5;
	private int numOfBeats = 0;
	private float lastTime;
	private Movement mvmt;
 
	static string fmt = "0#";

	void Start ()
	{
		startTime = .01f;    
		lastTime = 0.0f;
		mvmt = (Movement)GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent ("Movement");
	}
 
	void Update ()
	{
 
		if (startTime > 0) {
			elapsedTime = Time.time - startTime;
			
			Debug.Log ("Elapsed: " + elapsedTime + " vs Last: " + lastTime);
			if (beats < elapsedTime - lastTime) {
				foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Pulsing")) {
					obj.animation.CrossFade("Pulse");
				}
				lastTime = elapsedTime;
				numOfBeats++;
			}
			
			if (beatSpeed == numOfBeats) {
				numOfBeats = 0;
				mvmt.forwardSpeed = Mathf.Min(mvmt.forwardSpeed * 1.5f, 40.0f);
				beats /= 2;
			}
		}
	}
 
	void OnTriggerExit ()
	{
		startTime = 0;
	}
 
	void OnGUI ()
	{
		GUI.Label (new Rect (10, 0, 100, 20),
			(string.Format ("{0,2:" + fmt+"}:{1,2:" + fmt+"}", (int)elapsedTime / 60, 
						   (int)elapsedTime % 60)));
	}
}
