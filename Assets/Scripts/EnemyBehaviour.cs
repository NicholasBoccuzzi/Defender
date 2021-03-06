﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	private int health;
	private AudioSource enemyAudioPlayer;
	public AudioClip[] enemyAudioClips;
	public float timeBetween;
	private bool dead = false; 
	public GameObject explosion;
	public GameObject bullet;
	private GameObject game;
	private GameObject centerPointRef;
	private GameObject gameManager; 
	private Vector2 centerPoint;
	private Rigidbody2D rigid;
	private float RotateSpeed = 5f;
	private float Radius = 1f;
	private float _angle;
	public int personalCount;

	void Start () {
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		centerPointRef = GameObject.FindGameObjectWithTag("King");
		timeBetween = (Random.value * 2);
		enemyAudioPlayer = gameObject.GetComponent<AudioSource>();
		rigid = GetComponent<Rigidbody2D>();
		rigid.freezeRotation = true;
		game = GameObject.FindGameObjectWithTag("GameManager");

		if (this.tag == "Pawn") {
			health = 1;
		} else if (this.tag == "King") {
			health = 2;
		}
	}

	void Update () {
		if (!game.GetComponent<GameManager>().phaseActive) {
			updateTime();
			if (centerPointRef) {
				CircularRotate();
			}
		}
	}

	void updateTime() {
		timeBetween += Time.deltaTime;

		if (timeBetween  >= 3.0f && !this.dead) {
			Fire();
		}
	}

	void Fire() {
		GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
		newBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -10f, 0f);
		newBullet.GetComponent<Bullet>().enemyBullet = true;
		timeBetween = Random.Range(0.0f, 1.5f);
	}

	
	void CircularRotate() {
		if (this.tag != "King"){
			centerPoint = centerPointRef.transform.position;
			// _angle += RotateSpeed * Time.deltaTime;
	
			// var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
			transform.RotateAround(centerPoint, new Vector3(0, 0, RotateSpeed), 100*Time.deltaTime);
			// transform.position = centerPoint + offset;

			float angle = Mathf.Atan2(0, 0) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
		
	}



	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.GetComponent<Bullet>().enemyBullet == false) {
			health -=1 ;
			if (health <= 0) {
				this.dead = true;
				enemyAudioPlayer.PlayOneShot(enemyAudioClips[0]);
				GameObject newExplosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
				gameManager.GetComponent<GameManager>().enemiesRemaining -= 1;
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				gameObject.GetComponent<PolygonCollider2D>().enabled = false;
				Object.Destroy(this.gameObject, 2.0f);
			} else {
				enemyAudioPlayer.PlayOneShot(enemyAudioClips[1]);
			}
		}
	}

	
}
