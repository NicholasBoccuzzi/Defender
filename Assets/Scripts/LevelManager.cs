using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour {
    
	public int target = 60;
	private Scene currentScene;
	private string nextScene;
	private SceneManager sceneManager;
	private Image whiteWipe;
	private ImageFill imageFill;
	private bool fadingOut;
	public bool loading;
	public AudioSource audioplayer;

	void Awake()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = target;
	}

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
		currentScene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
        if(Application.targetFrameRate != target) {
              Application.targetFrameRate = target;
		}

		if (nextScene == "Game") {
			if (audioplayer != null) {
				StartCoroutine (AudioPlayer.FadeOut(audioplayer, 2.0f));
				audioplayer = null;
			}
		}
		
	}

	void loadLevel (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	// IEnumerator fadeInDefender() {
	// 	float fadeTime = gameObject.GetComponent<Fading>().BeginFade(1);
	// 	yield return new WaitForSeconds(fadeTime);
	// }

	public void loadDefender() {
		loadLevel("Game");
	}

	// sets loading to active so that ImageFill can wipescreen then call LoadDefender;
	public void setLoadingActive () {
		loading = true;
		nextScene = "Game";
	}



}