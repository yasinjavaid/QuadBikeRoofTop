using UnityEngine;
using System.Collections;

public class CarBalance : MonoBehaviour {

	bool doLerp = false;
	Quaternion toRotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.rotation.eulerAngles.z >= 60 && this.transform.rotation.eulerAngles.z <= 320){
			doLerp = true;
			toRotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, 0, 1);
		}else{
			doLerp = false;
		}

		if(this.transform.rotation.eulerAngles.z >= 150 && this.transform.rotation.eulerAngles.z <= 210){
			this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y + 0.1f, this.transform.position.z);
		}

		if(doLerp){
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, toRotation, Time.deltaTime);
		}
	}
}
