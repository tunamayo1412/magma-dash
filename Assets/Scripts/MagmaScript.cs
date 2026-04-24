using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagmaScript : MonoBehaviour {

    GameDirector gameDirector;

	// Use this for initialization
	void Start () {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            gameDirector.BombSound();
            gameDirector.GameOver();
        }
    }
}
