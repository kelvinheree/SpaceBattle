using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 1f;
    [SerializeField]
    private float thrusterForce = 1000f;

	private PlayerMotor motor;

	void Start(){
		motor = GetComponent<PlayerMotor>();
	}

	void Update(){
		//calc forward velocity
		float _boost = Input.GetAxisRaw("Accelerate");

		Vector3 _boostVector = transform.forward * _boost;

		//final movement vector
		Vector3 _velocity = (_boostVector).normalized * speed;

		//apply movement
		motor.Move(_velocity);

		//calc rotation as a 3D vector (turning around)
		float _yRot = Input.GetAxisRaw("Horizontal");
        float _xRot = Input.GetAxisRaw("Vertical");

		Vector3 _rotation = new Vector3(-_xRot, _yRot, 0f) * lookSensitivity;

		//apply rotation
		motor.Rotate(_rotation);

        //thruster force calculation
        Vector3 _thrusterForce = Vector3.zero;
        //apply thruster force
        if (Input.GetButton("Jump")){
            _thrusterForce = Vector3.up * thrusterForce;
        } 
        if (Input.GetButton("Fire2")){
            _thrusterForce = Vector3.down * thrusterForce;
        }

        motor.ApplyThruster(_thrusterForce);
	}
}
