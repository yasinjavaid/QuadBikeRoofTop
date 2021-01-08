using UnityEngine;
using System.Collections;

public class BoundryHurdle : MonoBehaviour {

	// Use this for initialization
	GameObject Player;
	public string axis ;
	public float max, min;
	void Start () {
		Invoke("findPlayer",1f);
	}
	void findPlayer()
	{
		Player = GameObject.FindGameObjectWithTag("Player2");
		//this.transform.position = new Vector3(Player.transform.position.x,this.transform.position.y,this.transform.position.z);
	}
	// Update is called once per frame
	void Update () {

		if(Player == null)
			return;
		if(axis == "x")
		{
			if(this.transform.position.x>min && this.transform.position.x<max)
			this.transform.position = new Vector3(Player.transform.position.x,this.transform.position.y,this.transform.position.z);
		}
		else if(axis == "z")
		{
			if(this.transform.position.z>min && this.transform.position.z<max)
			this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,Player.transform.position.z);
		}
	}
}
