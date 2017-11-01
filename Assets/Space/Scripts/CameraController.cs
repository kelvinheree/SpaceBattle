using UnityEngine;

[RequireComponent(typeof(CameraMotor))]
public class CameraController : MonoBehaviour {

    [SerializeField]
    private float lookSensitivity = 1f;

    private CameraMotor motor;

    void Start()
    {
        motor = GetComponent<CameraMotor>();
    }
	
	// Update is called once per frame
	void Update () {
        float _xRot = Input.GetAxisRaw("Mouse Y");
        float _yRot = Input.GetAxisRaw("Mouse X");

        float _cameraRotationX = _xRot * lookSensitivity;
        float _cameraRotationY = _yRot * lookSensitivity;

        motor.RotateCamera(_cameraRotationX, _cameraRotationY);
    }
}
