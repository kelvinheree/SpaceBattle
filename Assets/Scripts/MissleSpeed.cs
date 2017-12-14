using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleSpeed : MonoBehaviour {

	Rigidbody rb;
	public float speed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}

    /*private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            string _playerID = collider.name;
            Debug.Log(_playerID + " has been shot.");

            Player _player = GameManager.GetPlayer(_playerID);
            _player.RpcTakeDamage(20);
        } else
        {
            //Destroy(gameObject);
        }
    }*/


}
