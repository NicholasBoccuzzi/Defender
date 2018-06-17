using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		Destroy(this.gameObject);
	}
}
