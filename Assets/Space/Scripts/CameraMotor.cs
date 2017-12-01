using UnityEngine;

public class CameraMotor : MonoBehaviour {

    [SerializeField]
    private float cameraRotationLimit = 85f;

    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;
    private float cameraRotationY = 0f;
    private float currentCameraRotationY = 0f;

    public void RotateCamera(float _cameraRotationX, float _cameraRotationY)
    {
        cameraRotationX = _cameraRotationX;
        cameraRotationY = _cameraRotationY;
    }

    // Update is called once per frame
    void FixedUpdate () {
        Rotate();
	}

    void Rotate()
    {
        //set X rotation and clamp
        currentCameraRotationX -= cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        //apply rotation to the transform of camera
        

        //set Y rotation and clamp
        currentCameraRotationY += cameraRotationY;
        currentCameraRotationY = Mathf.Clamp(currentCameraRotationY, -cameraRotationLimit, cameraRotationLimit);

        //apply rotation to the transform of camera
        transform.localEulerAngles = new Vector3(currentCameraRotationX, currentCameraRotationY, 0f);
    }
}
