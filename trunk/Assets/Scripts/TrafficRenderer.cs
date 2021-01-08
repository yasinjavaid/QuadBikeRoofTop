using UnityEngine;
using System.Collections;

public class TrafficRenderer : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameVisible(){
		this.transform.root.GetComponent<Rigidbody> ().isKinematic = false;
		foreach (var wheel in this.transform.root.GetComponentsInChildren<Wheel>())
			wheel.enabled = true;
	}

	void OnBecameInvisible(){
		this.transform.root.GetComponent<Rigidbody> ().isKinematic = true;
		foreach (var wheel in this.transform.root.GetComponentsInChildren<Wheel>())
			wheel.enabled = false;
	}
}
