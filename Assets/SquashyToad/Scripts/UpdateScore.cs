using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {
    Text scoreText;
	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = FrogMovement.score.ToString();
	}
}
