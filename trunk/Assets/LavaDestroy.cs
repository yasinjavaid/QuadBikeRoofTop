using UnityEngine;
using System.Collections;

public class LavaDestroy : MonoBehaviour {
	Motor damagedMotor;
	public GameObject resetPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other) {
		if (other.transform.root.GetComponent<VehicleParent> ()) {
			other.transform.position=resetPosition.transform.position;
			other.transform.rotation=resetPosition.transform.rotation;

		}


	}
}
