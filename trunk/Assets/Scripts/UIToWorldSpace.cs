using UnityEngine;
using System.Collections;

public class UIToWorldSpace : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
//		if(target == null)
//			target = this.transform.parent.transform;
	}
	
	// Update is called once per frame
	void Update () {
		var wantedPos = Camera.main.WorldToViewportPoint (this.transform.position);
		this.transform.position = wantedPos;
	}
}
