﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	private int health;
	private AudioSource enemyAudioPlayer;
	public AudioClip[] enemyAudioClips;
	public float timeBetween;
	private bool dead = false; 
	public GameObject bullet;



	void Start () {
		timeBetween = (Random.value * 2);
		enemyAudioPlayer = gameObject.GetComponent<AudioSource>();

		if (this.tag == "Pawn") {
			health = 1;
		} else if (this.tag == "King") {
			health = 2;
		}
	}

	void Update () {
		updateTime();
	}

	void updateTime() {
		timeBetween += Time.deltaTime;

		if (timeBetween >= 3.0f && !this.dead) {
			GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
			newBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -10f, 0f);
			newBullet.GetComponent<Bullet>().enemyBullet = true;
			timeBetween = (Random.value * 3);
		} 
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.GetComponent<Bullet>().enemyBullet == false) {
			health -=1 ;
			if (health <= 0) {
				this.dead = true;
				enemyAudioPlayer.PlayOneShot(enemyAudioClips[0]);
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				gameObject.GetComponent<PolygonCollider2D>().enabled = false;
				Object.Destroy(this.gameObject, 2.0f);
			} else {
				enemyAudioPlayer.PlayOneShot(enemyAudioClips[1]);
			}
		}
	}

	
}
