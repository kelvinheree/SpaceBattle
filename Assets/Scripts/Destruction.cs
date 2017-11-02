using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {
	public GameObject destroyedVersion;
	// Use this for initialization
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			Instantiate (destroyedVersion, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
