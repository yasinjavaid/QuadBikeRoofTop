using UnityEngine;
using System.Collections;

public class SmoothFollowThief : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
//		target = GameObject.Find("EmptyBodyThief").transform;
//		transform.position = target.position;
//		transform.position = Vector3.forward * 5.5f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(target == null){
			target = GameObject.Find("EmptyBodyThief").transform;
		}
		if(target != null){
//			Debug.LogError(">>>>>>> fixed update targer not null");
			transform.position = target.position;
			transform.position -= Vector3.forward * 5.5f;
		}
	}
}
