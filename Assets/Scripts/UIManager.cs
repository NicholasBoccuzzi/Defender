using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public int phase; 
	public GameObject GameManager;
	private AudioSource uiAudio;
	public AudioClip[] uiAudioClips;
	private bool showPhase;
	private float timer;
	private bool timerStarted = false;
	public Text text;
	private Color color;
	private bool played = false;

	void Start () {
		timer = 10.0f;
		uiAudio = this.GetComponent<AudioSource>();
		phase = GameManager.GetComponent<GameManager>().phase;
		showPhase = GameManager.GetComponent<GameManager>().phaseActive;
		text = GetComponent<Text>();
		color = text.color;
		startTimer();
	}

	void Update () {
		text.text = "Phase " + phase.ToString();
		if (showPhase && timerStarted) {
			if (uiAudio && !played && timer <= 2.75) {
				uiAudio.PlayOneShot(uiAudioClips[0]);
				played = true;
			}
			timer -= Time.deltaTime;
			if (timer <= 3.0f) {
				color.a = (10 * timer/3.0f);
				GetComponent<Text>().color = color;
			}
			if (color.a <= 0f) {
				GameManager.GetComponent<GameManager>().phaseActive = false;
			}
		}
	}

	void startTimer () {
		if (showPhase && !timerStarted) {
			timer = 3.0f;
			timerStarted = true;
		}
	}

}
