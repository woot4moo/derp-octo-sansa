using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
	
	private Movement mvmt;
	private Rigidbody body;
	private Texture2D fadeTexture;
	public GUIStyle backgroundStyle = new GUIStyle();
	
	private Color currentScreenOverlayColor = new Color(0,0,0,0);	
	private Color targetScreenOverlayColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);	
	private Color deltaColor = new Color(0,0,0,0);		
	private int fadeGUIDepth = -1000;
	
	private string endString = "";
	
	public float force = 0.5f;
	
	void Awake() {
		fadeTexture = new Texture2D(1, 1); 	
		backgroundStyle.normal.background = fadeTexture;
		SetScreenOverlayColor(currentScreenOverlayColor);
	}
	
	void Start() {
		mvmt = (Movement)gameObject.GetComponent ("Movement");
		body = gameObject.rigidbody;
	}
	
	void Update() {
		if (mvmt.alive) {
			body.transform.position += body.velocity * Time.deltaTime;	
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag.Equals("Pulsing") || other.tag.Equals("Stopper")) {
			mvmt.alive = false;
			endString = "Game Over";
			StartFade(targetScreenOverlayColor, 2);
		} else if (other.tag.Equals("Pusher")) {
			body.velocity += other.transform.forward * force;
		} else if (other.tag.Equals("Destroyer")) {
			mvmt.alive = false;
			endString = "Game Over";
			StartFade(targetScreenOverlayColor, 2);
			//gameObject.SetActive(false);
		} else if (other.tag.Equals("EndGame")) {
			endString = "You Win";
			StartFade(targetScreenOverlayColor, 2);
			mvmt.alive = false;
			other.audio.Play();
		}
	}
	
	public void SetScreenOverlayColor(Color newScreenOverlayColor)
	{
		currentScreenOverlayColor = newScreenOverlayColor;
		fadeTexture.SetPixel(0, 0, currentScreenOverlayColor);
		fadeTexture.Apply();
	}
 
	private void OnGUI()
    {   
		// if the current color of the screen is not equal to the desired color: keep fading!
		if (currentScreenOverlayColor != targetScreenOverlayColor)
		{			
			// if the difference between the current alpha and the desired alpha is smaller than delta-alpha * deltaTime, then we're pretty much done fading:
			if (Mathf.Abs(currentScreenOverlayColor.a - targetScreenOverlayColor.a) < Mathf.Abs(deltaColor.a) * Time.deltaTime)
			{
				currentScreenOverlayColor = targetScreenOverlayColor;
				SetScreenOverlayColor(currentScreenOverlayColor);
				deltaColor = new Color(0,0,0,0);
			}
			else
			{
				// fade!
				SetScreenOverlayColor(currentScreenOverlayColor + deltaColor * Time.deltaTime);
			}
		}
 
		// only draw the texture when the alpha value is greater than 0:
		if (currentScreenOverlayColor.a > 0)
		{			
            		GUI.depth = fadeGUIDepth;
            		GUI.Label(new Rect(-10, -10, Screen.width + 10, Screen.height + 10), fadeTexture, backgroundStyle);
		}
		
		if (!mvmt.alive) {
			GUI.Label (new Rect(Screen.width/2 - 120, Screen.height / 2, 250, 50), endString, backgroundStyle);	
			if (GUI.Button(new Rect(Screen.width/2 - 40, Screen.height / 2 + 60, 80, 40), "Play Again")) {
				Application.LoadLevel(0);
			}
		}
    }
	
	// initiate a fade from the current screen color (set using "SetScreenOverlayColor") towards "newScreenOverlayColor" taking "fadeDuration" seconds
	public void StartFade(Color newScreenOverlayColor, float fadeDuration)
	{
		if (fadeDuration <= 0.0f)		// can't have a fade last -2455.05 seconds!
		{
			SetScreenOverlayColor(newScreenOverlayColor);
		}
		else					// initiate the fade: set the target-color and the delta-color
		{
			targetScreenOverlayColor = newScreenOverlayColor;
			deltaColor = (targetScreenOverlayColor - currentScreenOverlayColor) / fadeDuration;
		}
	}
	
}
