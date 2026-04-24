using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WallScript : MonoBehaviour {

    float speed;


    void Start() {
        speed = 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate () {
        gameObject.transform.Translate(0, 0, speed);
    }

    public void ChangeSpeed(float sp) {
        speed += sp;
    }
}
