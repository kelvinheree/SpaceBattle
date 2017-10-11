using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
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
	}

	public override void OnStartClient(){
		base.OnStartClient();
		string _netID = GetComponent<NetworkIdentity>().netId.ToString();
		Player _player = GetComponent<Player>();
		GameManager.RegisterPlayer(_netID, _player);
	}

	void OnDisable(){
		if (mainCam != null){
			mainCam.gameObject.SetActive(false);
		}
		GameManager.UnRegisterPlayer(transform.name);
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
