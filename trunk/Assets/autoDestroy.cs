using UnityEngine;
using System.Collections;

public class autoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
