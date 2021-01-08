using UnityEngine;
using System.Collections;

public class AnimationButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		playFadOutAnim();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void playFadOutAnim(){
		//iTween.ScaleFrom(this.gameObject, iTween.Hash("x", 1.5, "y",1.5, "z", 1,"time",4, "easetype","elastic"));
		//Invoke("playFadInOutAnim", .5f);

		iTween.ScaleTo(this.gameObject, iTween.Hash("x", 1.1, "y",1.1, "z", 1,"time",0.5, "easetype","elastic"));
		Invoke("playFadInAnim", 0.5f);
		//iTween.ScaleTo(timerLabel.transform.gameObject,new Vector3(timerLabel.transform.localScale.x+25f,timerLabel.transform.localScale.y+25f,1f),1f);
	}
	void playFadInAnim(){
		iTween.ScaleTo(this.gameObject, iTween.Hash("x", .9, "y",.9, "z", 1,"time",0.5, "easetype","elastic"));
		Invoke("playFadOutAnim", 0.5f);
	}
}
