﻿using UnityEngine;
using System.Collections;

public class ManuAnimations : MonoBehaviour {

	// Use this for initialization
	void Start () {
		/*Vector3 newPos = this.gameObject.transform.position;
		newPos.y += 1f;
		this.gameObject.transform.position = newPos;
		iTween.MoveTo(  this.gameObject, iTween.Hash(  "y",  -3f,  "time", 0.7, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void playAnimation(GameObject gameObject, int animationDirection){
		// Animation directions; 0 = from top; 1 = from bottom; 2 = from right; 3 = from left

		//iTween.moveb

		switch(animationDirection){
		case 0:
			Debug.Log("Animation direction: " + animationDirection);
			iTween.MoveFrom(gameObject, iTween.Hash(  "y",  gameObject.transform.position.y + 3f,  "time", 0.7, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
			break;
		case 1:
			Debug.Log("Animation direction: " + animationDirection);
			iTween.MoveFrom(gameObject, iTween.Hash(  "y",  gameObject.transform.position.y - 3f,  "time", 0.7, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
			break;
		case 2:
			Debug.Log("Animation direction: " + animationDirection);
			iTween.MoveFrom(gameObject, iTween.Hash(  "x",  gameObject.transform.position.x + 3f,  "time", 0.7, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
			break;
		case 3:
			Debug.Log("Animation direction: " + animationDirection);
			iTween.MoveFrom(gameObject, iTween.Hash(  "x",  gameObject.transform.position.x - 3f,  "time", 0.7, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
			break;
		default: // from top
			Debug.Log("Animation direction: Default");
			iTween.MoveFrom(gameObject, iTween.Hash(  "y",  gameObject.transform.position.y - 3f,  "time", 0.7, "easetype",iTween.EaseType.easeInOutCubic  )  );
			break;
		}
	}
}
