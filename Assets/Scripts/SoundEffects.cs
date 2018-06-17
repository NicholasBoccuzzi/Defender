using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {
	public AudioClip[] audioclips;
	private	GameObject soundEffectGameObject;
	private AudioSource soundEffectPlayer;

	void Start () {
		soundEffectGameObject = GameObject.Find("SoundEffects");
		soundEffectPlayer = soundEffectGameObject.GetComponent<AudioSource>();
	}

	void bulletFired() {
		if (soundEffectPlayer) {
			soundEffectPlayer.PlayOneShot(audioclips[0]);
		}
	}
}
