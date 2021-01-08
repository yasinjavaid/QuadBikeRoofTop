using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	// Use this for initialization
	float speed = 100f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate (){
		transform.Rotate(0, 0, Time.deltaTime * speed * -1);
	}
}
