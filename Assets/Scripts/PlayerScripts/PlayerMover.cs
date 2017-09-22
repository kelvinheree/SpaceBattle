using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

	public float forwardSpeed = 10f;
	public float sideSpeed = 5f;
    public float horizontalRotateSpeed = 1.0f;
	public float verticalRotateSpeed = 1.0f;
	public float brakeSpeed=5f;
	public float boostSpeed = 10f;
    Rigidbody rb;

	Vector3 pos;
	Vector3 lastPos;
	Vector3 veloSub=Vector3.zero;
	Vector3 relaVelo;

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

		pos = transform.position;
		veloSub = pos - lastPos;
		lastPos = pos;
		relaVelo = rb.velocity - veloSub;

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * forwardSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * -forwardSpeed);
        }
		if (Input.GetKey ("space")) {
			Vector3 rev = -relaVelo;
			rb.AddForce (rev*brakeSpeed);

		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			rb.AddForce (transform.forward * boostSpeed);
		}
        
        
        /*
        float horz = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");
		Vector3 move = new Vector3 (horz*sideSpeed,0f,vert*sideSpeed);
		rb.AddForce (move);
        */
	}
}
