using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	void Start () {
		Debug.Log(this.tag);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Destroy(this.gameObject);
	}
}
