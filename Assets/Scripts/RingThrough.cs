using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingThrough : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			Debug.Log ("Good job");
		}
	}
}
