using UnityEngine;
using System.Collections;

public class SheildController : MonoBehaviour {

	// Use this for initialization

	private bool activeState=false;
	private bool deadState=false;
	[RangeAttribute(0, 1)]
	public float health=1.0f;
	Motor damagePart;
	public int numOfHits=10;
	private float damageHealthFactor=0.0f;
	public float damageCause=0.0025f;
	void Start () {
		damageHealthFactor = 1 / 10f;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
//		if (!activeState && !deadState) {
//			GameObject parent=collision.gameObject;
//			if(parent.GetComponent<VehicleParent>())
//			{
//				activeState=true;
//				GameObject shield=null;
//				if(this.gameObject.name=="Saw")
//				shield=parent.transform.FindChild("Saw").gameObject;
//				if(shield)
//				{
//				this.gameObject.transform.root.transform.position=shield.transform.position;
//				this.gameObject.transform.root.transform.rotation=shield.transform.rotation;
//					this.gameObject.transform.root.transform.parent=parent.transform;
//				}
//
//
//			}
//			if(activeState&&!deadState)
//			{
//				if(this.tag=="Sheild")
//				{
//
//
//				}
//
//			}
//		}

//		if (!deadState) {
//			if(collision.gameObject.GetComponent<EnemyCar>())
//			{
//				damagePart = collision.gameObject.transform.root.GetComponent<VehicleDamage> ().damageParts [0].GetComponent<Motor> ();
//				float damagedIntensity=this.gameObject.transform.root.gameObject.GetComponent<Rigidbody>().velocity.magnitude*damageCause*(1-damagePart.strength);
//				if(damagedIntensity>Constants.EnemyCarThreshold)
//				{
//				
//					damagePart.health-=Constants.EnemyCarThreshold;
//
//				}
//				else
//				{
//					damagePart.health-=damagedIntensity;
//				}
//
//				health-=damageHealthFactor;
//
//
//			}
//
//
//
//		}
//		if (health < 0) {
//
//			deadState=true;
//			this.gameObject.transform.parent=null;
//			this.GetComponent<Rigidbody>().isKinematic=false;
//			Destroy(this.gameObject,4.0f);
//		}
//
//
//
	}


}
