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
	private float brakeSpeed=1f;


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
    private Rigidbody rb;
	private PlayerMotor motor;

    //Missle Variables
    public bool missiles = false;
    public GameObject Missile;
    public GameObject ShotSpawn;

    //Zone stuff
    public bool inZone = true;
    private int zoneCounter = 0;
    

    //Vince's Garbage
    private bool boostBool;
	private float boostFloat;
	private float _boost;
	Vector3 pos;
	Vector3 lastPos;
	Vector3 veloSub = Vector3.zero;
	Vector3 relaVelo;
	Vector3 brakeVec;

    void Start ()
	{
		motor = GetComponent<PlayerMotor>();
        rb = GetComponent<Rigidbody>();
    }

	void Update ()
	{
		

		if (PauseMenu.IsOn)
			return;

        //Setting target position for spring
        //This makes the physics act right when it comes to
        //applying gravity when flying over objects
        //RaycastHit _hit;
        //if (Physics.Raycast(transform.position, Vector3.down, out _hit, 100f, environmentMask))
        //{
        //    joint.targetPosition = new Vector3(0f, -_hit.point.y, 0f);
        //}
        //else
        //{
        //    joint.targetPosition = new Vector3(0f, 0f, 0f);
        //}

        //calc forward velocity

		if (Input.GetKey (KeyCode.W)) {
			_boost = 1f;
		} else if (Input.GetKey (KeyCode.S)) {
			_boost = -1f;
		} else {
			_boost= 0f;
		}
         
//        float _boost = Input.GetAxisRaw("Accelerate");

        Vector3 _boostVector = transform.forward * _boost;

        //final movement vector
        Vector3 _velocity = (_boostVector).normalized * speed;

        //apply movement
        motor.Move(_velocity);

		//braking
		pos = transform.position;
		veloSub = pos - lastPos;
		lastPos = pos;
		relaVelo = rb.velocity - veloSub;

		if (Input.GetKey ("space")) {
			Vector3  vec= -relaVelo;
			brakeVec = vec * brakeSpeed;
		} else {
			brakeVec = Vector3.zero;
		}

		motor.Brake (brakeVec);

        //calc rotation as a 3D vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _rotation = new Vector3(-_xRot, _yRot, 0f) * lookSensitivity;

        //apply rotation

        motor.Rotate(_rotation);

        //if (Input.GetButton("Fire3"))
        //{

        //}
        //else
        //{
        //    motor.Rotate(_rotation);
        //}


		if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -shipRotateSpeed);
        }

		if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, shipRotateSpeed);
        }



        // Calculate the thrusterforce based on player input
        Vector3 _thrusterForce = Vector3.zero;
		if (Input.GetKey(KeyCode.LeftShift) && thrusterFuelAmount > 0f)
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
//		motor.ApplyThruster(_thrusterForce);

        //fires missles if the player has them
        if (Input.GetMouseButtonDown(1) && missiles)
        {
            Instantiate(Missile, ShotSpawn.transform.position, ShotSpawn.transform.rotation);
        }

        if (!inZone)
        {
            Player _player = GameManager.GetPlayer(gameObject.name);
            _player.RpcTakeDamage(1);
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Wormhole")
        {
            Vector3 destination = new Vector3(Random.Range(0, 150), Random.Range(0, 150), Random.Range(0, 150));
            rb.transform.position = destination;
        }

        if (collider.tag == "Missile")
        {
            Player _player = GameManager.GetPlayer(gameObject.name);
            _player.RpcTakeDamage(100);
           // missiles = true;
           Destroy(collider.gameObject);
        }
        if (collider.tag == "Boundary")
        {
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Boundary")
        {
            inZone = false;
        }
    }
}
