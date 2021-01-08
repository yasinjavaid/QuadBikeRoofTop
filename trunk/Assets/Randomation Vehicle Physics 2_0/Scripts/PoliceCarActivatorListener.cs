using UnityEngine;
using System.Collections;

public class PoliceCarActivatorListener : MonoBehaviour {

	// Use this for initialization
	private GameObject parent;
	void Start () {
		parent = this.gameObject.transform.root.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider CollisionInfo) {


		if (CollisionInfo.tag == "Player2") {
			if(!this.gameObject.GetComponentInParent<PoliceCarActivatorLocalize>().isActive())
			{	
				parent.GetComponent<BlockageSpawner> ().disableAllBlockage ();
			//	this.gameObject.GetComponentInParent<PoliceCarActivatorLocalize>().ResetCarPosition();
				this.gameObject.GetComponentInParent<PoliceCarActivatorLocalize>().policeCarActivator();}


		}

	}
}
