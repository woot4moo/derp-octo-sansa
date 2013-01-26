using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{

	private float startTime;
	private float elapsedTime;
 
	static string fmt = "0#";

	void Start ()
	{
		startTime = .01f;      
	}
 
	void Update ()
	{
 
		if (startTime > 0) {
			elapsedTime = Time.time - startTime;
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
