using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveLeft();
		MoveRight();
	}

	void MoveLeft() {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position = new Vector3(transform.position.x - .2f, -4f, 0.0f);
		}
	}
	
	void MoveRight() {
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position = new Vector3(transform.position.x + .2f, -4f, 0.0f);
		}
	}
}
