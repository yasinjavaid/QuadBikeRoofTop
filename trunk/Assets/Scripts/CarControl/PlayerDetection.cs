using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnTriggerEnter (Collider collisionInfo){
//		Debug.LogError ("Trigger with "+ collisionInfo.tag);
		if(collisionInfo.tag=="Police"){
			GameObject.FindWithTag("Hud").GetComponent<HudMenuLocalize>().ShowEnterButton(true);
			TutorialManagerNew.Instance.ChangeState(TutorialManagerNew.TutorialState.SHOWENTERBTNARROW);
		}
	}
	void  OnTriggerExit (Collider collisionInfo){
		//Debug.LogError ("Trigger with "+ collisionInfo.tag);
		if(collisionInfo.tag=="Police"){
			GameObject.FindWithTag("Hud").GetComponent<HudMenuLocalize>().ShowEnterButton(false);
			TutorialManagerNew.Instance.ChangeState(TutorialManagerNew.TutorialState.HIDEENTERBTNARROW);
		}
	}
}
