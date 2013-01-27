using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{

	private float startTime;
	private float elapsedTime;
	public float beats = 5;
	private int beatSpeed = 5;
	private int numOfBeats = 0;
	private float lastTime;
	private Movement mvmt;
	private GameObject[] pulsers;
 
	static string fmt = "0#";
	
	public float maxForwardSpeed = 50.0f;
	public float maxturnSpeed = 5.0f;
	
	private float animLength;
	
	private GameObject plaque;
	
	public GUIStyle style = new GUIStyle();

	void Start ()
	{
		startTime = .01f;    
		lastTime = 0.0f;
		mvmt = (Movement)gameObject.GetComponent ("Movement");
		pulsers = GameObject.FindGameObjectsWithTag("Pulsing");
		animLength = pulsers[0].animation.clip.length;
		plaque = GameObject.Find("plaque");
	}
	
	public void Reset() {
		startTime = 0.1f;
		lastTime = 0.0f;
	}
 
	void Update ()
	{
		if (startTime > 0) {
			elapsedTime = Time.timeSinceLevelLoad - startTime;
			
			bool changeSpeed = false;
			
			if(animLength > beats)
			{
				changeSpeed = true;
			}
			
			if (beats < elapsedTime - lastTime) {
				if (!plaque.audio.isPlaying) {
				foreach (GameObject obj in pulsers) {
					if (changeSpeed) {
						foreach (AnimationState state in obj.animation) {;
							if (beats < 0.01) {
								state.speed = 8;	
								animLength = state.length / state.speed;
							} else {
								state.speed = state.length / beats;
								animLength = state.length / state.speed;
							}
						}
					}
					obj.animation.Play("Pulse");
				}
				
					plaque.audio.Play();
				}
				lastTime = elapsedTime;
				numOfBeats++;
			}
			
			if (beatSpeed == numOfBeats) {
				numOfBeats = 0;
				mvmt.forwardSpeed = Mathf.Min(mvmt.forwardSpeed * 1.5f, maxForwardSpeed);
				mvmt.turnSpeed = Mathf.Min(mvmt.turnSpeed * 1.25f, maxturnSpeed);
				beats = Mathf.Max(beats/2, Mathf.Epsilon);
			}
		}
	}
 
	void OnGUI ()
	{
		GUI.Label (new Rect (10, 0, 100, 20),
			(string.Format ("{0,2:" + fmt+"}:{1,2:" + fmt+"}", (int)elapsedTime / 60, 
						   (int)elapsedTime % 60)), style);
	}
}
