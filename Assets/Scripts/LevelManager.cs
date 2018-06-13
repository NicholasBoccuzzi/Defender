using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

	private Scene currentScene;
	private SceneManager sceneManager;

	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void loadLevel (string name) {
		SceneManager.LoadScene(name);
	}

	// IEnumerator fadeInDefender() {
	// 	float fadeTime = gameObject.GetComponent<Fading>().BeginFade(1);
	// 	yield return new WaitForSeconds(fadeTime);
	// }

	public void loadDefender() {
		print("hello");
		loadLevel("Level_01");		
	}


}
