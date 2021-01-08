using UnityEngine;
using System.Collections;

public class ParametersDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		GetComponent<GUIText>().text="Heigth   : "+CameraControlPP.height+"\n Distance  : "+CameraControlPP.distance;
	}
}
