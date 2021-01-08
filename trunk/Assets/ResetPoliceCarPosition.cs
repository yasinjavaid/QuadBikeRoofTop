using UnityEngine;
using System.Collections;

public class ResetPoliceCarPosition : MonoBehaviour {

	// Use this for initialization
	private Vector3 policecarPosition;
	private Quaternion policeRotation;
	private bool checkIsStartCall=false;
	void Start () {
		checkIsStartCall = true;
		policecarPosition = this.gameObject.transform.position;
		policeRotation = this.gameObject.transform.rotation;
	}

	
	// Update is called once per frame
	void Update () {
	
	}
	void OnEnable() {
		if (checkIsStartCall) {

			this.gameObject.transform.position = policecarPosition;
			this.gameObject.transform.rotation = policeRotation;
		}
	}
}
