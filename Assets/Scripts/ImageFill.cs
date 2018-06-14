using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFill : MonoBehaviour {
    Image whiteWipe;
    public bool complete;
	private bool started;
    private float waitTime = 2.0f;
	private LevelManager levelManager;
	private AudioSource audioplayer;

	void Start() {
		whiteWipe = gameObject.GetComponent<Image>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		audioplayer = GameObject.FindObjectOfType<AudioSource>();
	}
    // Update is called once per frame
    void Update()
    {	
            //Reduce fill amount over 30 seconds
		if (levelManager.loading) {
			if (!started) {
				transform.localScale = new Vector3(10.0f, 1, 1);
				whiteWipe.fillAmount = .5f;
				started = true;
			}
			whiteWipe.fillAmount += 1.0f / waitTime * Time.deltaTime;
			if (whiteWipe.fillAmount == 1.0f) {
				complete = true;

				levelManager.loadDefender();
			}
		}
    }
}
