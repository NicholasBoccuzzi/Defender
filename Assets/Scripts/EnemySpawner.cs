using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpawner : MonoBehaviour {
	private GameObject enemy;
	private int x = 0;
	

	// Use this for initialization
	void Start () {
		// transform is attached to EnemyFormation because this script is attached to EnemyFormation;
		// Want to make sure that the enemy is instantiated inside of the EnemyFormation
		// Get 'enemy' out of Instantiate by setting 'GameObject enemy' (declared above) = the instantiation below, but must instantiate 'as' a GameObject (seen below).
		
		// for each being used to equip each position with an instance of an enemy.
		int count = 1;
		foreach( Transform child in transform) {
			if (count == 1) {
				generateEnemy("Assets/Entities/King.prefab", child);
				count += 1;
			} else {
				generateEnemy("Assets/Entities/Pawn.prefab", child);
				count += 1;				
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void generateEnemy(string path, Transform child) {
		enemy = Instantiate(AssetDatabase.LoadAssetAtPath(path, typeof(GameObject)), child.transform.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = child;
	}
}
