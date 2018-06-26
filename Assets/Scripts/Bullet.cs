using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private AudioSource bulletAudio;
	public bool enemyBullet = false;
	public AudioClip[] bulletClips;

	// Use this for initialization

	void Awake() {
		bulletAudio = gameObject.GetComponent<AudioSource>();
	}

	void Start () {
		bulletAudio.PlayOneShot(bulletClips[0]);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void moveUp() {
	}

	void OnTriggerEnter2D(Collider2D col) {
		Destroy(this.gameObject);
	}


}
