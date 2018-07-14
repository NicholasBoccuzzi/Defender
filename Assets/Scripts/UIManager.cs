using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public int phase; 
	public GameObject GameManager;
	private bool showPhase;
	private float timer;
	private bool timerStarted = false;
	public Text text;
	private Color color;

	void Start () {
		timer = 10.0f;
		phase = GameManager.GetComponent<GameManager>().phase;
		showPhase = GameManager.GetComponent<GameManager>().phaseActive;
		text = GetComponent<Text>();
		color = text.color;

		startTimer();
	}

	void Update () {
		text.text = "Phase " + phase.ToString();
		if (showPhase && timerStarted) {
			timer -= Time.deltaTime;
			if (timer <= 5.0f) {
				color.a = (2 * timer/5.0f);
				GetComponent<Text>().color = color;
			}
			if (color.a <= 0f) {
				showPhase = false;
			}
		}
	}

	void startTimer () {
		if (showPhase && !timerStarted) {
			timer = 10.0f;
			timerStarted = true;
		}
	}

}
