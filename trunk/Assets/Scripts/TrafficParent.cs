using UnityEngine;
using System.Collections;

public class TrafficParent : MonoBehaviour {

	Transform _mParent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		_mParent = this.transform.parent;
		this.transform.parent = null;
	}

	public void OnDisableSetParent(){
		this.transform.parent = _mParent;
	}

}
