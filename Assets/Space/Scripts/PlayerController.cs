using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 3f;
    [SerializeField]
    private float thrusterForce = 1000f;

	private PlayerMotor motor;

	void Start(){
		motor = GetComponent<PlayerMotor>();
	}

	void Update(){
		//calc movement velocity as a 3D vector
		float _xMove = Input.GetAxisRaw("Horizontal");
		float _zMove = Input.GetAxisRaw("Vertical");

		Vector3 _moveHorizontal = transform.right * _xMove;
		Vector3 _moveVertical = transform.forward * _zMove;

		//final movement vector
		Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

		//apply movement
		motor.Move(_velocity);

		//calc rotation as a 3D vector (turning around)
		float _yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

		//apply rotation
		motor.Rotate(_rotation);

		//calc camera rotation as a 3D vector (turning around)
		float _xRot = Input.GetAxisRaw("Mouse Y");

		Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

		//apply rotation
		motor.RotateCamera(_cameraRotation);

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
