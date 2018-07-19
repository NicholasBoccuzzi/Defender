using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationAutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
