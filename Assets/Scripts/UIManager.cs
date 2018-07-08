using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public int phase; 
	public GameObject GameManager;
	private bool showPhase;


	void Start () {
		phase = GameManager.GetComponent<GameManager>().phase;
		showPhase = GameManager.GetComponent<GameManager>().phaseActive;
	}

	void startTimer () {
		if 
	}

}
