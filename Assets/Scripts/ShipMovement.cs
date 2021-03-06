﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

	public GameObject game;
	public GameObject bullet;
	public GameObject explosion;
	public AudioClip[] shipClips;
	private float speed = 20.0f;
	private float padding = .2f;
	float xmin;
	float xmax;

	void Awake () {
	}

	// Use this for initialization
	void Start () {

		// finding the right distance to each side of the camera.
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3 (1, 0, distance));

		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		if (game.GetComponent<GameManager>().phaseActive) {
			transform.position =new Vector3(0, -4, 0);
		}

		if (!game.GetComponent<GameManager>().phaseActive) {
			MoveLeft();
			MoveRight();
			if (Input.GetKeyDown(KeyCode.Space)) {
				fire();
			}
		}

		// Below can be used if I want to allow holding down space for the ship to continuously fire
		// if (Input.GetKeyDown(KeyCode.Space)) {
		// 	InvokeRepeating("fire", 0.000001f, .2f);
		// }

		// if (Input.GetKeyUp(KeyCode.Space)){
		// 	CancelInvoke("fire");
		// }

			

		// restrict player to playspace		
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

	void MoveLeft() {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
			// can also use transform.position -= Vector3.left * speed * Time.deltaTime;
		}
	}
	
	void MoveRight() {
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
			// can also use transform.position += Vector3.right * speed * Time.deltaTime;
		}
	}

	void fire() {
			GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
			newBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 10f, 0f);
	}

	void cancelFire() {
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.GetComponent<Bullet>().enemyBullet == true) {
			GameObject newExplosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.GetComponent<AudioSource>().PlayOneShot(shipClips[0]);
			Destroy(this.gameObject, 2.0f);
			Destroy(collider.gameObject);
		}
	}

}
