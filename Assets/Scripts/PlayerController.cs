using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 3f;
    [SerializeField]
    private float shipRotateSpeed = 1f;



	[SerializeField]
	private float thrusterForce = 1000f;

	[SerializeField]
	private float thrusterFuelBurnSpeed = 1f;
	[SerializeField]
	private float thrusterFuelRegenSpeed = 0.3f;
	private float thrusterFuelAmount = 1f;

	public float GetThrusterFuelAmount ()
	{
		return thrusterFuelAmount;
	}

	[SerializeField]
	private LayerMask environmentMask;

	// Component caching
	private PlayerMotor motor;

	void Start ()
	{
		motor = GetComponent<PlayerMotor>();
	}

	void Update ()
	{
		if (PauseMenu.IsOn)
			return;

        //Setting target position for spring
        //This makes the physics act right when it comes to
        //applying gravity when flying over objects
        //RaycastHit _hit;
        //if (Physics.Raycast (transform.position, Vector3.down, out _hit, 100f, environmentMask))
        //{
        //	joint.targetPosition = new Vector3(0f, -_hit.point.y, 0f);
        //} else
        //{
        //	joint.targetPosition = new Vector3(0f, 0f, 0f);
        //}

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

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 0f, -shipRotateSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, 0f, shipRotateSpeed);
        }

        // Calculate the thrusterforce based on player input
        Vector3 _thrusterForce = Vector3.zero;
		if (Input.GetButton ("Jump") && thrusterFuelAmount > 0f)
		{
			thrusterFuelAmount -= thrusterFuelBurnSpeed * Time.deltaTime;

			if (thrusterFuelAmount >= 0.01f)
			{
				_thrusterForce = Vector3.up * thrusterForce;
			}
		} else
		{
			thrusterFuelAmount += thrusterFuelRegenSpeed * Time.deltaTime;
		}

		thrusterFuelAmount = Mathf.Clamp(thrusterFuelAmount, 0f, 1f);

		// Apply the thruster force
		motor.ApplyThruster(_thrusterForce);

	}
}
