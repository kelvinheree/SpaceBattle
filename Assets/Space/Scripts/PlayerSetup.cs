using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {
	[SerializeField]
	Behaviour[] componentsToDisable;
	[SerializeField]
	string remoteLayerName = "RemotePlayer";

	Camera mainCam;

	void Start(){
		if (!isLocalPlayer){
			DisableComponents();
			AssignRemoteLayer();
		} else {
			mainCam = Camera.main;
			if (mainCam != null){
				mainCam.gameObject.SetActive(false);
			}
		}

		RegisterPlayer();
	}

	void RegisterPlayer(){
		string _ID = "Player " + GetComponent<NetworkIdentity>().netId;
		transform.name = _ID;
	}

	void OnDisable(){
		if (mainCam != null){
			mainCam.gameObject.SetActive(false);
		}
	}

	void DisableComponents(){
		for (int i = 0; i < componentsToDisable.Length; i++){
			componentsToDisable[i].enabled = false;
		}
	}

	void AssignRemoteLayer(){
		gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
	}
}
