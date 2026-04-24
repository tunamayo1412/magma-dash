using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentScript : MonoBehaviour {

    [SerializeField]
    GameObject sencer;

    private void Start() {
        sencer = GameObject.Find("Sencer (2)");
    }

    // Update is called once per frame
    void Update () {
        if (gameObject.transform.position.z <= sencer.transform.position.z) Destroy(gameObject);
    }
}
