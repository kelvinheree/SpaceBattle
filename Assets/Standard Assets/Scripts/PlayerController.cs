using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    // public var myCam : Camera;
    // public var myAudioListener : AudioListener;

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        //rotation
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //movement
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);



    }

    public override void OnStartLocalPlayer()
    {
          //Client code
          // if (myCam.enabled == false){
          //     myCam.enabled = true;
          // }
          //
          // if (myAudioListener.enabled == false){
          //     myAudioListener.enabled = true;
          // }
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
