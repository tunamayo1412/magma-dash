using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour {

    [SerializeField]
    GameObject rock_1;
    [SerializeField]
    GameObject rock_2;
    [SerializeField]
    GameObject magma;
    [SerializeField]
    GameObject crystal;
    [SerializeField]
    GameObject wall;
    [SerializeField]
    GameObject sencer;
    GameObject parent;
    int mapX = 18;
    float maxHeight = 3f;
    float relief = 10f;
    int x;
    int z;
    float random;
    int i;

    // Use this for initialization
    void Start () {
        random = Random.value * 100;
        x = 0;
        z = 0;
        MapCreate();
    }
	
	// Update is called once per frame
	void Update () {

        if(parent.transform.position.z <= sencer.transform.position.z) {
            MapCreate();
        }
    }

    void MapCreate() {
        parent = new GameObject("Enpty object");
        parent.AddComponent<ParentScript>();
        parent.transform.position = new Vector3(0, 0, z);
        z++;
        for (x = 0; x <= mapX; x++) {
            GameObject cube;
            float xSample = (x + random) / relief;
            float zSample = (z + random) / relief;
            float perlin = Mathf.PerlinNoise(xSample, zSample);
            float y = maxHeight * perlin;
            y = Mathf.Round(y);
            if (y <= 1f) {
                cube = Instantiate(magma);
            } else if(y == 2){
                cube = Instantiate(rock_1);
            } else {
                cube = Instantiate(rock_2);
                GameObject Crystal = Instantiate(crystal);
                Crystal.transform.SetParent(parent.transform);
                Crystal.transform.localPosition = new Vector3(x, y, 0);
                y -= 1;
            }
            cube.transform.SetParent(parent.transform);
            cube.transform.localPosition = new Vector3(x, y, 0);
        }
    }
}
