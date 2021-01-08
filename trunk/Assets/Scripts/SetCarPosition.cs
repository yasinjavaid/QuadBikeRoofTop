using UnityEngine;
using System.Collections;

public class SetCarPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("setCarPosition",1f);
	}
	public	void setCarPosition()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player2");
		player.transform.position = this.transform.position;
		player.transform.rotation = this.transform.rotation;
	}
	public void setCarPosition(GameObject player)
	{

		player.transform.position = new Vector3(this.transform.position.x,this.transform.position.y+2,this.transform.position.z);
		player.transform.rotation = this.transform.rotation;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
