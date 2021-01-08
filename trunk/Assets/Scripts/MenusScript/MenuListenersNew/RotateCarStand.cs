using UnityEngine;
using System.Collections;

public class RotateCarStand : MonoBehaviour {

	// Use this for initialization
	float speed = 30f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate (){
		transform.Rotate(0, Time.deltaTime * speed, 0);
	}
}
