using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	private int health;
	private AudioSource enemyAudioPlayer;
	public AudioClip[] enemyAudioClips;



	void Start () {
		enemyAudioPlayer = gameObject.GetComponent<AudioSource>();

		if (this.tag == "Pawn") {
			health = 1;
		} else if (this.tag == "King") {
			health = 2;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
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
