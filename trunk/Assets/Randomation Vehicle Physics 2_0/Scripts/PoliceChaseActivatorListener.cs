using UnityEngine;
using System.Collections;

public class PoliceChaseActivatorListener : MonoBehaviour {

	// Use this for initialization


	private GameObject parent;
	void Start () {
		parent = this.gameObject.transform.parent.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider CollisionInfo)
	{
		if(CollisionInfo.tag=="Player2")
		{
			if(!parent.GetComponent<PoliceChaseActivatorLocalize>().isActive())
			{

				parent.GetComponent<PoliceChaseActivatorLocalize>().chaseCar(CollisionInfo.gameObject);
					//parent.GetComponent<PoliceChaseActivatorLocalize>().ActivePoliceChasingCars();

			}



		}


	}
}
