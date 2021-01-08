using UnityEngine;
using System.Collections;

public class skipTutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		Instructions.isSkipped = true;
	}
}
