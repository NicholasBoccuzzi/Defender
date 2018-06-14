using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpawner : MonoBehaviour {
	private GameObject enemy;
	private int x = 0;
	public float width = 10f;
	public float height = 5f;
	private float speed = 10f;
	private float yVal;
	float xmin;
	float xmax;
	float padding = 1.2f;
	public bool moveLeft = true;

	

	// Use this for initialization
	void Start () {
		yVal = transform.position.y;
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3 (1, 0, distance));

		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;

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

	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		moveEnemyGroup();
		checkPosition();
	}

	void generateEnemy(string path, Transform child) {
		enemy = Instantiate(AssetDatabase.LoadAssetAtPath(path, typeof(GameObject)), child.transform.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = child;
	}

	void moveEnemyGroup() {
		if (moveLeft) {
			transform.position -= new Vector3(speed * Time.deltaTime, yVal, 0.0f);
		} else {
			transform.position += new Vector3(speed * Time.deltaTime, yVal, 0.0f);
		}
	}

	void checkPosition() {
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		if (newX == xmin) {
			yVal = -.05f;
			moveLeft = false;
		} else if (newX == xmax) {
			yVal = .05f;
			moveLeft = true;
		} else {
			yVal = 0.0f;
		}

		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
