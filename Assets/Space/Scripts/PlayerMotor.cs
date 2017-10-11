using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Camera cam;

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 cameraRotation = Vector3.zero;
    private Vector3 thrusterForce = Vector3.zero;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
			rb = GetComponent<Rigidbody>();
	}

	//Gets a movement vector
	public void Move(Vector3 _velocity){
		velocity = _velocity;
	}

    //Gets a rotate vector
	public void Rotate(Vector3 _rotation){
		rotation = _rotation;
	}

    //Gets a vector for rotating camera
	public void RotateCamera(Vector3 _cameraRotation){
		cameraRotation = _cameraRotation;
	}

    //Gets the thrusterForce vector
    public void ApplyThruster(Vector3 _thrusterForce){
        thrusterForce = _thrusterForce; 
    }

	// Run every physics iteration
	void FixedUpdate() {
		PerformMovement();
		PerformRotation();
	}

	// Perform movement based on velocity variable
	void PerformMovement(){
		if (velocity != Vector3.zero){
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
        if (thrusterForce != Vector3.zero){
            rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
	}

	void PerformRotation(){
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
		if (cam != null){
			cam.transform.Rotate(-cameraRotation);
		}
	}


}
