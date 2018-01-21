using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVehicle : MonoBehaviour {
    public float speed=10f;
	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<Rigidbody>().MovePosition(transform.position - Vector3.right*speed * Time.deltaTime);
        //transform.Translate(-speed*Time.deltaTime,0,0);
	}
}
