using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

	float forwardSpeed = 10f;
	float sideSpeed = 5f;
    float horizontalRotateSpeed = 1.0f;
    float verticalRotateSpeed = 1.0f;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

    void Update()
    {
        float h = horizontalRotateSpeed * Input.GetAxis("Mouse X");
        float v = verticalRotateSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(-v, h, 0);
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * forwardSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * -forwardSpeed);
        }
        
        
        /*
        float horz = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");
		Vector3 move = new Vector3 (horz*sideSpeed,0f,vert*sideSpeed);
		rb.AddForce (move);
        */
	}
}
