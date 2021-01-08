using UnityEngine;
using System.Collections;

public class TrafficDetector : MonoBehaviour {

	public FollowAI followAI;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnTriggerEnter (Collider collisionInfo){
//		if (collisionInfo.transform.root.CompareTag("Player2") || collisionInfo.transform.parent.CompareTag("Trafic")) {
//			followAI.SetEmergencyStop(true);
//		}
	}

	void  OnTriggerExit (Collider collisionInfo){
//		if (collisionInfo.transform.root.CompareTag("Player2") || collisionInfo.transform.parent.CompareTag("Trafic")) {
//			followAI.SetEmergencyStop(false);
//		}
	}
}
