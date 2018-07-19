using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	private int phase; 
	public GameObject GameManager;
	private AudioSource uiAudio;
	public AudioClip[] uiAudioClips;
	private bool textPhaseActive;
	private float timer;
	private bool timerStarted = false;
	public Text text;
	private Color color;
	private bool played = false;
	private bool displayPhaseCalled = false;

	void Start () {
		timer = 5.0f;
		uiAudio = this.GetComponent<AudioSource>();
		text = GetComponent<Text>();
		textPhaseActive = GameManager.GetComponent<GameManager>().phaseActive;
		color = text.color;
		startTimer();
	}

	void Update () {
		displayPhase ();
	}

	void startTimer () {
		if (textPhaseActive && !timerStarted) {
			timerStarted = true;
		}
	}

	void displayPhase() {
		if (textPhaseActive && timer >= 0.0f) {
			timer -= Time.deltaTime;
			phase = GameManager.GetComponent<GameManager>().phase;
			text.text = "Phase " + phase.ToString();
			if (timer <= 3.0f) {
				color.a = (10 * timer/3.0f);
				GetComponent<Text>().color = color;
			}
			if (uiAudio && !played && timer <= 2.75) {
				uiAudio.PlayOneShot(uiAudioClips[0]);
				played = true;
			}

		} else if (textPhaseActive) {
			textPhaseActive = false;
			color.a = 0.0f;
			GetComponent<Text>().color = color;
			GameManager.GetComponent<GameManager>().phaseActive = false;
			played = false;
			timerStarted = false;
		}
	}

	public void activateTextPhase () {
		Debug.Log("Hit");
		color.a = 1.0f;
		GetComponent<Text>().color = color;
		textPhaseActive = true;
		timer = 4.0f;
		startTimer();
	}

}
