using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour {
    float maxdir0, maxdir1, maxdir2;
    public float []speed;
    int counter = 0;
    int jumpCount = 0;
    public GameObject uiElement;
    public GameObject screenSpaceCameraCanvas;

    public static int score;
    Vector3 rotateJump;

    private void Awake()
    {
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        score = 0;
        //screenSpaceCameraCanvas.gameObject.SetActive(true);
    }
    // Use this for initialization
    void Start () {
        maxdir0= Mathf.Deg2Rad * 45;
        maxdir1= Mathf.Deg2Rad * 55;
        maxdir2= Mathf.Deg2Rad * 65;
    }
	
	// Update is called once per frame
	void Update () {
        //bool onGround = Physics.Raycast(transform.position, -transform.up,0.7f);
        bool onGround = counter > 0 ? true : false;
        if (onGround)
            jumpCount = 0;
        //bool speedlimit = GetComponent<Rigidbody>().velocity.magnitude < speedtolarance;
        if (Input.GetButtonDown("Fire1") && onGround)
        {
            Jump();
            jumpCount = 0;
        }
        if (!onGround)
        {
            if (jumpCount < 2)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    jumpCount++;
                    Jump();
                }
            }
        }
    }

    void Jump()
    {
        Vector3 cameraForward = GetComponentInChildren<Camera>().transform.forward;
        Vector3 lookDirection = Vector3.ProjectOnPlane(cameraForward, Vector3.up);
        if(jumpCount==0)
          rotateJump = Vector3.RotateTowards(lookDirection, Vector3.up, maxdir0, 0);
        if (jumpCount == 1)
            rotateJump = Vector3.RotateTowards(lookDirection, Vector3.up, maxdir1, 0);
        if(jumpCount==2)
           rotateJump = Vector3.RotateTowards(lookDirection, Vector3.up, maxdir2, 0);
        Vector3 normalisedJump = rotateJump.normalized * speed[jumpCount];
        GetComponent<Rigidbody>().AddForce(normalisedJump, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Lethal")
        {
            //screenSpaceCameraCanvas.gameObject.SetActive(false);
            uiElement.gameObject.SetActive(true);
            Destroy(GetComponent<Rigidbody>());
            GetComponent<FrogMovement>().enabled = false;
        }

        if (collision.transform.parent.GetComponent<ScoreOnSafePlatform>())
        {
            score++;
            counter++;
            Destroy(collision.transform.parent.GetComponent<ScoreOnSafePlatform>());
        }
        else
            counter++;
    }

    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.name == "Log")
        counter--;
    }
}
