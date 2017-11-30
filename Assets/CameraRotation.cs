using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire2"))
        {
            float _yRot = Input.GetAxisRaw("Mouse X");
            float _xRot = Input.GetAxisRaw("Mouse Y");
            Vector3 _rotation = new Vector3(-_xRot, _yRot, 0f) * 5;
            transform.Rotate(_rotation, 2f);
        }
	}
}
