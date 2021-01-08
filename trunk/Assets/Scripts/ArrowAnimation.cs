using UnityEngine;
using System.Collections;

public class ArrowAnimation : MonoBehaviour {

	public Vector3 to;
	public Vector3 from;
	public float time = 0.5f;
	public bool isLocal = true;
	public bool ignoreTimeScale = true;


	// Use this for initialization
	void Start () {
		Animate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Animate(){
		if(isLocal){
			this.transform.localPosition = from;
		}else{
			this.transform.position = from;
		}

		iTween.MoveTo(this.gameObject, iTween.Hash("position",to,"time",time,"isLocal",isLocal,"ignoreTimeScale",ignoreTimeScale,"onComplete","AnimateReverse"));
	}

	void AnimateReverse(){
		if(isLocal){
			this.transform.localPosition = to;
		}else{
			this.transform.position = to;
		}

		iTween.MoveTo(this.gameObject, iTween.Hash("position",from,"time",time,"isLocal",isLocal,"ignoreTimeScale",ignoreTimeScale,"onComplete","Animate"));
	}
}
