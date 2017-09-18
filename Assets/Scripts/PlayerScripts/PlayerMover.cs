using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

	float forwardSpeed=10f;
	float sideSpeed=5f;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horz = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");
		Vector3 move = new Vector3 (horz*sideSpeed,0f,vert*sideSpeed);
		rb.AddForce (move);
	}
}
