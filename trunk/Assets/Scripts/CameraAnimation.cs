using UnityEngine;
using System.Collections;

public class CameraAnimation : MonoBehaviour {
	
	public GameObject midCamera;
	public GameObject finalCamera;
	public GameObject target;

	void OnEnable(){
		MoveToMidPosition();
		target = GameObject.Find("EmptyBodyThief");
	}

	// Use this for initialization
	void Start () {
	
	}

	void Update(){

	}

	// Update is called once per frame
	void LateUpdate () {
		this.transform.LookAt(target.transform);
	}

	void MoveToMidPosition(){
		iTween.MoveTo(this.gameObject, iTween.Hash("position", midCamera.transform.localPosition, "isLocal", true,"time",1f,"onComplete","MoveToFinalPosition","easeType",iTween.EaseType.linear));
	}

	void MoveToFinalPosition(){
		iTween.MoveTo(this.gameObject, iTween.Hash("position", finalCamera.transform.localPosition, "isLocal", true,"time",1f,"easeType",iTween.EaseType.linear));
	}
}
