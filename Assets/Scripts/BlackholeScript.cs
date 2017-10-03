using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BlackholeScript : MonoBehaviour {

	//pub

	public Shader shader;
	public Transform blackhole;
	public float ratio; //aspect ratio
	public float radius;


	//pri
	Camera cam;
	Material _mat;// procedurally generated

	Material material{
		get { 
			if (_mat == null) {
				_mat = new Material (shader);
				_mat.hideFlags = HideFlags.HideAndDontSave;
			}
			return _mat;
		}
	}

	void OnEnable(){
		cam = GetComponent<Camera> ();
		ratio = 1f / cam.aspect;
	}

	void OnDisable(){
		if (_mat) {
			DestroyImmediate (_mat);
		}
	}

	Vector3 wtsp;

	Vector2 pos;

	void OnRenderImage(RenderTexture source, RenderTexture destination){
		if (shader && material && blackhole) {
			wtsp = cam.WorldToScreenPoint (blackhole.position);

			//is black hole in front of cam

			if(wtsp.z>0){
				pos = new Vector2 (wtsp.x / cam.pixelWidth, wtsp.y / cam.pixelHeight);
				//apply shader
				_mat.SetVector("_Position", pos);
				_mat.SetFloat ("_Ratio", ratio);
				_mat.SetFloat ("_Rad", radius);
				_mat.SetFloat ("_Distance", Vector3.Distance (blackhole.position, transform.position));


				//apply shader
				Graphics.Blit(source, destination,material);
			}
		}
	}

}
