using UnityEngine;
using System.Collections;

public class carResetPosition : MonoBehaviour {

	// Use this for initialization

	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Surface") {
			Invoke("resetPosition",2.0f);

		}
	}
	void resetPosition()
			       {
		Transform t = this.gameObject.transform.root;
		//t.localPosition = new Vector3 (0, gameObject.transform.localPosition.y+2,0);
		t.eulerAngles = new Vector3 (0, t.eulerAngles.y, 0);

			}
}
