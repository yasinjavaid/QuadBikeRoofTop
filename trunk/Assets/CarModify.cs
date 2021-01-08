using UnityEngine;
using System.Collections;

public class CarModify : MonoBehaviour {
	public GameObject player;
	private bool check=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!check){
		if (player)
			modify ();
			if(player==null)
			{
				player=GameObject.FindGameObjectWithTag("Player2");
			}


	}
	}
	void modify()
	{
	check=true;
		Wheel [] wheels= player.GetComponent<VehicleParent>().wheels;
//		wheels[0].sidewaysFriction=8;
//		wheels[1].sidewaysFriction=8;
//		wheels[2].sidewaysFriction=6f;
//		wheels[3].sidewaysFriction=6f;
//		player.GetComponent<Rigidbody>().mass=5000


	}
}
