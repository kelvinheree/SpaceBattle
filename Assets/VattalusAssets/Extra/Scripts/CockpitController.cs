using UnityEngine;

public class CockpitController : MonoBehaviour
{
    [Header("Control Parameters")]
    public float turnspeed = 5f;
    public float strafeSpeed = 5f;
    public float yawTorque = 1f;
    public float pitchTorque = 1f;
    public float rollTorque = 1f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

#if !UNITY_EDITOR
        Cursor.visible = false;
#endif
    }

    private void Update()
    {
        float roll = 0f;
        if (Input.GetKey(KeyCode.E)) roll -= 1;
        if (Input.GetKey(KeyCode.Q)) roll += 1;

        float pitch = 0f;
        if (Input.GetKey(KeyCode.S)) pitch -= 1;
        if (Input.GetKey(KeyCode.W)) pitch += 1;

        float yaw = 0f;
        if (Input.GetKey(KeyCode.A)) yaw -= 1;
        if (Input.GetKey(KeyCode.D)) yaw += 1;

        rb.AddRelativeTorque(pitch * turnspeed * Time.deltaTime * pitchTorque, yaw * turnspeed * Time.deltaTime * yawTorque,
            roll * turnspeed * Time.deltaTime * rollTorque);

        //#if !UNITY_EDITOR
        //        if (Input.GetKeyDown(KeyCode.Escape))
        //            Application.Quit();
        //#endif
    }
}
