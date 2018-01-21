using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.gameObject.tag == "Lethal")
            Destroy(other.transform.parent.gameObject);
        else
            Destroy(other.gameObject);
    }
}
