using UnityEngine;
using System.Collections;

public class ReflexTestTrigger : MonoBehaviour {

	public ReflexTest reflexTest;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnTriggerEnter (Collider collisionInfo){
		if (collisionInfo.transform.root.CompareTag("Player2")) {
			reflexTest.isTriggerEntered = true;
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
