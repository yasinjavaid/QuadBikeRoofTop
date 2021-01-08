using UnityEngine;
using System.Collections;

public class CamLookAtNew : MonoBehaviour {

	// Use this for initialization
	Transform target;
	SmoothFollow sf;
	void Start () {

		sf = GetComponent<SmoothFollow>();
	}
	
	// Update is called once per frame
	void Update () {
		if(sf.target==null)
		{
			if(target==null)
			{
				GameObject obj =  GameObject.Find ("COM");
				if(obj!=null)
				target =obj.transform;
			}
			else
			Camera.main.transform.LookAt(target);
		}
	}
}
