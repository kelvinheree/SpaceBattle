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

	public float horizontalRotateSpeed = 2.0f;
	public float verticalRotateSpeed = 2.0f;

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

		float h = horizontalRotateSpeed * Input.GetAxis("Mouse X");
    float v = verticalRotateSpeed * Input.GetAxis("Mouse Y");
		motor.Rotate(v,h);

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
