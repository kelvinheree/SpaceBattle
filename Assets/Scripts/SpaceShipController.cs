using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{

    public float forwardSpeed = 10f;
    public float sideSpeed = 5f;
    public float horizontalRotateSpeed = 1.0f;
    public float verticalRotateSpeed = 1.0f;
    public float brakeSpeed = 5f;
    public float boostSpeed = 10f;
    public float shipRotateSpeed = 1f;
    public float missileSpeed = 5000f;
    public bool missiles = false;
    public GameObject Missile;
    public GameObject ShotSpawn;
    Rigidbody rb;

    Vector3 pos;
    Vector3 lastPos;
    Vector3 veloSub = Vector3.zero;
    Vector3 relaVelo;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = horizontalRotateSpeed * Input.GetAxis("Mouse X");
        float v = verticalRotateSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(-v, h, 0);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -shipRotateSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, shipRotateSpeed);
        }

        if (Input.GetMouseButtonDown(1) && missiles)
        {
            GameObject Missiles = Instantiate(Missile, ShotSpawn.transform.position, ShotSpawn.transform.rotation) as GameObject;
            //Missiles.GetComponent<Rigidbody>().AddForce(transform.forward * missileSpeed);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        pos = transform.position;
        veloSub = pos - lastPos;
        lastPos = pos;
        relaVelo = rb.velocity - veloSub;

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * forwardSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * -forwardSpeed);
        }


        if (Input.GetKey("space"))
        {
            Vector3 rev = -relaVelo;
            rb.AddForce(rev * brakeSpeed);

        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(transform.forward * boostSpeed);
        }


        /*
        float horz = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");
		Vector3 move = new Vector3 (horz*sideSpeed,0f,vert*sideSpeed);
		rb.AddForce (move);
        */
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
            missiles = true;
            Destroy(collider.gameObject);
        }
    }
}