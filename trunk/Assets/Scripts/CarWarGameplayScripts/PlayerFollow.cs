using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {

	// Use this for initialization
	GameObject p;
	void Start () {
		this.transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		if(p==null)
		{
			p = GameObject.FindGameObjectWithTag("Player2");
		}
		else
		{

			this.transform.position = new Vector3(p.transform.position.x,p.transform.position.y+14f,p.transform.position.z);
			this.transform.eulerAngles = new Vector3(90,p.transform.eulerAngles.y,0);
		}
	}
}
