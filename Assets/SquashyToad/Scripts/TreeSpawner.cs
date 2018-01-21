using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {
    public GameObject tree;
    float deptInsideFloor = 1.5f;
    // Use this for initialization
    void Start () {
        int randomTreeDensity = Random.Range(3,6);
        for (int i = 1; i <= randomTreeDensity; i++)
            GenerateTrees();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateTrees()
    {
        float randomX = Random.RandomRange(-45, 45);
        float randomZ = Random.RandomRange(-5, 5);
        GameObject newTree = Instantiate(tree);
        newTree.transform.parent = transform;
        if(transform.position.z==0)
            newTree.transform.position = new Vector3(randomX,-deptInsideFloor,randomZ);
        else
        {
            float cal = transform.position.z / 10;
            newTree.transform.position = new Vector3(randomX, -deptInsideFloor, randomZ+(cal*10));
        }
    }
}
