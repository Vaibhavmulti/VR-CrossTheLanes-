using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject spawnVehicle;

    float spawnTime=0;
    float SpawnInterval;
    int randomVehicle;
    // Use this for initialization
    void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
        SpawnInterval = Random.RandomRange(2f,4f);
            //randomVehicle = Random.Range(0, 2);
        if(Time.time>spawnTime)
        {
            GameObject newVehicle=Instantiate(spawnVehicle,transform.position,transform.rotation,transform);
            spawnTime += SpawnInterval;
        }
	}
}
