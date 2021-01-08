using UnityEngine;
using System.Collections;

public class CheckpointTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnTriggerEnter (Collider collisionInfo){
		if (collisionInfo.transform.root.CompareTag("Player2")) {
		//	this.transform.parent.parent.GetComponent<Checkpoints>().NextCheckpoint();
		//	this.gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
