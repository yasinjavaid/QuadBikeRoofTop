using UnityEngine;
using System.Collections;

public class LightFlareEffect : MonoBehaviour {
	
	public bool isFirst;
	float intensityFactor = 0.5f;
	int iteration = 0;

	void OnEnable(){
		if(isFirst){
			MoveRight();
		}else{
			MoveLeft();
		}
		StartCoroutine(LightIntensity());
	}

	void MoveLeft(){
		if(this.gameObject != null){
			if(isFirst){ 
				this.GetComponent<Light>().intensity = 0.5f;
				intensityFactor = -0.5f;
				this.transform.localPosition = new Vector3(0.54f, transform.localPosition.y, transform.localPosition.z);
				iTween.MoveFrom(this.gameObject,iTween.Hash("x", 0.16f, "time", 0.5f, "isLocal", true,"easeType", iTween.EaseType.linear,"onComplete","MoveRight"));
			}
			else{
				this.GetComponent<Light>().intensity = 0.5f;
				intensityFactor = 0.5f;
				this.transform.localPosition = new Vector3(-0.16f, transform.localPosition.y, transform.localPosition.z);
				iTween.MoveFrom(this.gameObject,iTween.Hash("x", -0.54f, "time", 0.5f, "isLocal", true,"easeType", iTween.EaseType.linear,"onComplete","MoveRight"));
			}
		}
	}

	void MoveRight(){
		if(this.gameObject != null){
			if(isFirst){ 
				this.GetComponent<Light>().intensity = 0.5f;
				intensityFactor = 0.5f;
				this.transform.localPosition = new Vector3(0.16f, transform.localPosition.y, transform.localPosition.z);
				iTween.MoveFrom(this.gameObject,iTween.Hash("x", 0.54f, "time", 0.5f, "isLocal", true,"easeType", iTween.EaseType.linear,"onComplete","MoveLeft"));
			}
			else{
				this.GetComponent<Light>().intensity = 0.5f;
				intensityFactor = -0.5f;
				this.transform.localPosition = new Vector3(-0.54f, transform.localPosition.y, transform.localPosition.z);
				iTween.MoveFrom(this.gameObject,iTween.Hash("x", -0.16f, "time", 0.5f, "isLocal", true,"easeType", iTween.EaseType.linear,"onComplete","MoveLeft"));
			}

		}
	}

	IEnumerator LightIntensity(){
		while(true){
			if(this.gameObject != null){
				this.GetComponent<Light>().intensity += intensityFactor;
				yield return new WaitForSeconds(0.25f);
			}
		}
	}
}
