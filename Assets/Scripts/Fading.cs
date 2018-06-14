using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture; // the texture that will overlay the screen. Loading image or black screen;
	public float fadeSpeed = .08f; // the fading speed
	private int drawDepth = -1000; // the texture's order in the draw hierarchy. set so high so that it is always on top
	private float alpha = 1.0f; // the texture starts out completely visable (opacity)
	private int fadeDir = -1; // the direction of fade: in = -1 or out = 1;
	

	void OnGUI () {
		//  fade out/in the alpha using a direction, a speed, and a Time.deltatime to convert the operation to seconds

		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		//  force (clamp) the number between 0 and 1 because the GUI.color uses alpha values between 0 and 1;
		alpha = Mathf.Clamp01(alpha);

		// set color of our GUI (in this case our texture). All color values remain the same and the Alpha is set to the alpha variable
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);	//set alpha value;
		GUI.depth = drawDepth;	// make the black texture render on top;
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture); // Draw the teture to fit the entire screen;
	}


	// sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1;
	public float BeginFade (int direction) {
		fadeDir = direction;
		return (fadeSpeed); // return the fadeSpeed variable so it's easy to time with Application.loadLevel();
	}


	void OnEnable()
	{
	//Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}
         
	void OnDisable()
	{
	//Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}
         
	// OnLevelWasLoaded is called when a level is loaded. It takes a loaded level index (int) asa parameter so you can limit the fade in to certain scenes
	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		BeginFade (-1);
	}
		// alpha = 1  // Use this alpha if the alpha is not set to 1 by default;
		 // call the fadeInFunction
}
