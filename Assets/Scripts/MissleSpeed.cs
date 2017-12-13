using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleSpeed : MonoBehaviour {

	Rigidbody rb;
	public float speed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}
	

}
