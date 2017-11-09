using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {
	Rigidbody rb;
	public float bulletSpeed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity=transform.forward*bulletSpeed;
	}
	
	// Update is called once per frame

}
