using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	private int health; 

	void Start () {
		if (this.tag == "Pawn") {
			health = 1;
		} else if (this.tag == "King") {
			health = 2;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		health -=1 ;

		if (health <= 0) {
			Destroy(this.gameObject);
		}
	}
}
