using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public int phase; 
	public GameObject GameManager;
	private bool showPhase;
	private float timer;
	private bool timerStarted;

	void Start () {
		phase = GameManager.GetComponent<GameManager>().phase;
		showPhase = GameManager.GetComponent<GameManager>().phaseActive;
	}

	void Update () {
		if (showPhase && timerStarted) {
			timer -= Time.deltaTime;
			if	(timer <= 2.5f) {

			}
			if (timer <= 0) {

			}
		}
	}

	void startTimer () {
		if (showPhase && !timerStarted) {
			timer = 5.0f;
			timerStarted = true;
		}
	}

}
