using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Camera cam;

	private Vector3 velocity = Vector3.zero;
	private Vector3 brake = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 thrusterForce = Vector3.zero;

	[SerializeField]
	private float cameraRotationLimit = 85f;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Gets a movement vector
	public void Move (Vector3 _velocity)
	{
		velocity = _velocity;
        
	}

	public void Brake (Vector3 _brake)
	{
		brake = _brake;

	}


	// Gets a rotational vector
	public void Rotate(Vector3 _rotation)
	{
		rotation = _rotation;
	}
	
	// Get a force vector for our thrusters
	public void ApplyThruster (Vector3 _thrusterForce)
	{
		thrusterForce = _thrusterForce;
	}

	// Run every physics iteration
	void FixedUpdate ()
	{
		PerformMovement();

		PerformBrake ();
		

		PerformRotation();
	}

    // Perform movement based on velocity variable
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
//            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
			rb.AddForce( velocity * Time.deltaTime,ForceMode.VelocityChange);
        }

//        if (thrusterForce != Vector3.zero)
//        {
//			rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
//        }
    }

	void PerformBrake(){
		rb.AddForce (brake*Time.deltaTime);
	}

    void PerformRotation()
    {
        //transform.Rotate(rotation);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    }

}
