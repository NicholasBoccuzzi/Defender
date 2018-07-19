using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public int score = 0;
	public int enemiesRemaining = 0;
	public int phase = 0;
	public bool phaseActive = false;
	private int[] enemyCounts = new int[] {0, 0, 0, 0, 0, 0};

	// Use this for initialization
	void Awake () {
		for (int i = 0; i < enemyCounts.Length; i++) {
			enemyCounts[i] = 5 * i;
		}
	}

	void Start () {		
		Debug.Log(enemyCounts);
	}
	
	// Update is called once per frame
	void Update () {

		checkEnemyCount();
	}

	void checkEnemyCount () {
		if (enemiesRemaining == 0 && phaseActive == false) {
			phaseActive = true;
			phase += 1;
			enemiesRemaining = enemyCounts[phase];
		}
	}


}
