using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShot : MonoBehaviour {
    public float speed;
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        speed = 5000;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
    }
	
	// Update is called once per frame
	void Update () {
    }
}
