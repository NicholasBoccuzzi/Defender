using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour {
    
	public int target = 60;
	private Scene currentScene;
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

		if (currentScene.name == "Game") {
			audioplayer = AudioSource.FindObjectOfType<AudioSource>();
		}
	}
	
	// Update is called once per frame
	void Update () {
        if(Application.targetFrameRate != target) {
              Application.targetFrameRate = target;
		}

		if (currentScene.name == "Game") {
			if (audioplayer != null) {
				StartCoroutine (AudioPlayer.FadeOut(audioplayer, 10.0f));
				audioplayer = null;
			}
		}
		
	}

	void loadLevel (string name) {
		SceneManager.LoadScene(name);
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
	}



}