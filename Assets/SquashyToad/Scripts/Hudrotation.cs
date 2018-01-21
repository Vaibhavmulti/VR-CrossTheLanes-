using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hudrotation : MonoBehaviour {
    Camera mainCamera;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        mainCamera = transform.parent.GetComponentInChildren<Camera>();
        Vector3 lookDirection = mainCamera.transform.forward;
        Vector3 projectToPlane = Vector3.ProjectOnPlane(lookDirection, Vector3.up);
        transform.rotation = Quaternion.LookRotation(projectToPlane);
	}
}
