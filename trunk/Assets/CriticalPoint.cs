using UnityEngine;
using System.Collections;

public class CriticalPoint : MonoBehaviour {

	// Use this for initialization
	Motor damagePart;
	void Start () {
		damagePart = this.gameObject.transform.root.GetComponent<VehicleDamage> ().damageParts [0].GetComponent<Motor> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player2") {

			float damagedIntensity=col.gameObject.GetComponent<Rigidbody>().velocity.magnitude*0.0025f*(1-damagePart.strength);
			this.GetComponent<Renderer>().material.SetColor("_TintColor", Color.red);
			Invoke("changeColorToYellow",2.0f);
			if(damagedIntensity>Constants.EnemyCarThreshold)
			{
				damagePart.health-=Constants.EnemyCarThreshold;



			}
			else
			{

				damagePart.health-=damagedIntensity;
			}

		}


	}
	void changeColorToYellow()
	{
				this.GetComponent<Renderer>().material.SetColor("_TintColor",Color.yellow );
	}


}
