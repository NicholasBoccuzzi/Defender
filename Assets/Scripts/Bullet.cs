using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private GameObject soundEffectGameObject;
	public AudioClip[] audioclips;

	// Use this for initialization
	void Start () {
		soundEffectGameObject = GameObject.Find("SoundEffects"); 
	}
	
	// Update is called once per frame
	void Update () {
	}

	void moveUp() {
	}


}
