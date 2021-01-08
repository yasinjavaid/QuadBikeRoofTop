using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (target == null)
			return;

		this.transform.LookAt(target);
		this.transform.localEulerAngles = new Vector3 (this.transform.localEulerAngles.x , this.transform.localEulerAngles.y , this.transform.localEulerAngles.z );
	}

	public void SetTarget(Transform target){
		this.target = target;
	}
}
