using UnityEngine;
using System.Collections;

public class TruckFix : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		this.transform.eulerAngles = new Vector3 (this.transform.eulerAngles.x, this.transform.eulerAngles.y, 0);
	}
}
