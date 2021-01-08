using UnityEngine;
using System.Collections;

public class RockSliding : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void  OnTriggerEnter (Collider collisionInfo){
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY){	
			if(collisionInfo.name=="Truck Body"){
				this.transform.parent.GetComponent<Rigidbody>().useGravity = true;
				SmoothFollow.StartShake();
				Destroy(this);
			}
			
			
		}
	}
}
