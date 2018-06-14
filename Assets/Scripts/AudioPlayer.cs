using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour {

	private Scene currentScene;
	private GameObject title;
	private AudioSource audioplayer;
	public AudioClip[] audioClips;
	private LevelManager levelManager;
	static AudioPlayer instance = null;

	void Awake() {
		if (instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}


	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene();
		levelManager = GetComponent<LevelManager>();

		if (currentScene.name == "MainMenu") {
			title = GameObject.FindGameObjectWithTag("Title");
			audioplayer = GameObject.FindObjectOfType<AudioSource>();
		}
	}

	public void playMenuHover() {
		audioplayer.PlayOneShot(audioClips[0]);
	}

	public void playGameStart() {
		audioplayer.PlayOneShot(audioClips[1]);
	}

	public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
	

        while (audioSource.volume > 0.0f) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
 
        audioSource.Stop ();
        audioSource.volume = startVolume;
		Object.Destroy(audioSource);
    }


}
