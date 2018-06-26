using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	private int health;
	private AudioSource enemyAudioPlayer;
	public AudioClip[] enemyAudioClips;
	public float timeBetween = 0.0f;
	public GameObject bullet;



	void Start () {
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

		if (timeBetween >= 3) {
			GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
			newBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -10f, 0f);
			newBullet.GetComponent<Bullet>().enemyBullet = true;
			timeBetween = 0;
		} 
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.GetComponent<Bullet>().enemyBullet == false) {
			health -=1 ;
			if (health <= 0) {
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
