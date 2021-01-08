using UnityEngine;
using System.Collections;

public class MoveWithItween : MonoBehaviour {

	public Vector3 orignalPosition;
	public Vector3 finalPoistion;
	public float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable(){
		Move ();
	}

	void OnDisable(){
		MoveBack ();
	}

	void Move(){
		this.transform.localPosition = orignalPosition;
		iTween.MoveTo(this.gameObject,iTween.Hash("position",finalPoistion,"time",time,"isLocal",true,"easeType",iTween.EaseType.linear));
	}

	void MoveBack(){
		this.transform.localPosition = finalPoistion;
		iTween.MoveTo(this.gameObject,iTween.Hash("position",orignalPosition,"time",time,"isLocal",true,"easeType",iTween.EaseType.linear));
	}
}
