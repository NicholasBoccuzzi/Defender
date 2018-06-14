using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemy;
	private int x = 0;
	

	// Use this for initialization
	void Start () {
		// transform is attached to EnemyFormation because this script is attached to EnemyFormation;
		// Want to make sure that the enemy is instantiated inside of the EnemyFormation
		// Get 'enemy' out of Instantiate by setting 'GameObject enemy' (declared above) = the instantiation below, but must instantiate 'as' a GameObject (seen below).
		enemy = Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Entities/StartingEnemy.prefab", typeof(GameObject)), new Vector3(0,0,0), Quaternion.identity) as GameObject;
		enemy.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
