using UnityEngine;
using System.Collections;

public class healthincrementer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player2")
		other.GetComponentInChildren<Motor> ().health += 0.2f;

	}
}
