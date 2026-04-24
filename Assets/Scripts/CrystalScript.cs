using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour {
    
    GameDirector gameDirector;

    private void Start() {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(0.5f, 0.8f, 1.0f);
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            gameDirector.TakeScore(10);
            gameDirector.CrystalSound();
            Destroy(gameObject);
        }
    }
}
