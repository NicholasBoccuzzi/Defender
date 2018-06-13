using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleAudio : MonoBehaviour {

	private Scene currentScene;
	private GameObject title;
	private AudioSource audio;
	public AudioClip[] audioClips;

	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene();

		if (currentScene.name == "MainMenu") {
			title = GameObject.FindGameObjectWithTag("Title");
			audio = GameObject.FindObjectOfType<AudioSource>();
		}


	}

	public void playMenuHover() {
		audio.PlayOneShot(audioClips[0]);
	}

}
