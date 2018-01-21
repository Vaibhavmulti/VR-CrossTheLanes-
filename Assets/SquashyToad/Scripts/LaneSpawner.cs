using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSpawner : MonoBehaviour {
    public GameObject[] dangerLanePrefabs;
    public GameObject safeLanePrefab;
    enum LaneType { Safe, Danger};
    LaneType lastLaneType = LaneType.Safe;
    int offset;

    public GameObject player;
	// Use this for initialization
	void Start () {
        offset = 0;
    }
	
	// Update is called once per frame
	void Update () {
        while (offset <= 200 + player.transform.position.z)
        {
            GenerateLane(offset);
            offset += 10;
        }

        foreach(Transform trans in transform)
        {
            if (trans.position.z +200 <player.transform.position.z)
                Destroy(trans.gameObject);
        }
    }

    public void GenerateLane(int offset)
    {
        if(lastLaneType==LaneType.Safe)
        {
            int randomInt = Random.Range(0, dangerLanePrefabs.Length);
            GameObject newLane = Instantiate(dangerLanePrefabs[randomInt]) as GameObject;
            newLane.transform.parent = transform;
            newLane.transform.position = new Vector3(0, 0, offset);
            lastLaneType = LaneType.Danger;
        }
        else
        {
            GameObject newLane = Instantiate(safeLanePrefab) as GameObject;
            newLane.transform.parent = transform;
            newLane.transform.position = new Vector3(0, 0, offset);
            lastLaneType = LaneType.Safe;
        }
    }
}
