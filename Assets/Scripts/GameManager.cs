using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int score = 0;
	public Text[] UIManagers;
	public int enemiesRemaining = 5;
	public int phase = 1;
	public bool phaseActive = true;
	private int[] enemyCounts = new int[] {0, 0, 0, 0, 0, 0};

	// Use this for initialization
	void Awake () {
		for (int i = 0; i < enemyCounts.Length; i++) {
			enemyCounts[i] = 5 * i;
		}
	}

	void Start () {	

	}
	
	// Update is called once per frame
	void Update () {
		checkForPhase();
		checkEnemyCount();
	}

	void checkForPhase () {
		if (enemiesRemaining <= 0 && !phaseActive) {
			// Debug.Log("hitting checkForPhase");
			phaseActive = true;
			Debug.Log(phaseActive);
		}
	}

	public void checkEnemyCount () {
		if (enemiesRemaining <= 0 && phaseActive == true) {
			phase += 1;
			enemiesRemaining = enemyCounts[phase];
			for (int i = 0; i < UIManagers.Length; i++)
			{
				UIManagers[i].GetComponent<UIManager>().activateTextPhase();
			}
		}
	}
}
