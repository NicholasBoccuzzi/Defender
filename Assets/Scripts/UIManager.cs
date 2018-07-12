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
		Debug.Log(showPhase);
		startTimer();
	}

	void Update () {
		Debug.Log(text.color.a);
		text.text = "Phase " + phase.ToString();
		if (showPhase && timerStarted) {
			timer -= 2 * Time.deltaTime;
			if (timer <= 5.0f) {
				color.a = (timer/5.0f);
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
