using UnityEngine;
using System.Collections;

public class EnginePowerManager : MonoBehaviour {

	// Use this for initialization
	public GameObject engine;

	float value=0f;
	float mass=0;
	float enemymass=0;
	float playermass=0;
	float wheelFriction;
	float wheelFriction1;
	Wheel [] wheels;
	private float time;
	GameObject player;
	public GameObject Ragdoll;
	public GameObject Character;
	CamAnimation anim;
	void Start () {
	
	anim = GameObject.FindObjectOfType<CamAnimation> ();
		value=engine.gameObject.GetComponent<GasMotor> ().power;
		mass=this.GetComponent<Rigidbody>().mass;
		 
	
		wheels=engine.gameObject.transform.root.GetComponent<VehicleParent>().wheels;
		wheelFriction=wheels[0].forwardFriction;
		wheelFriction1=wheels[2].forwardFriction;
	//	GameObject.Find("CFD").GetComponent<BoxCollider>().enabled = true;
		playermass = Constants.playerMass;
	}
	
	// Update is called once per frame
	void Update () {




			if (this.GetComponent<Rigidbody> ().velocity.magnitude < 8 && this.tag == "Player2") {
				wheels [0].forwardFriction = 20;
				wheels [1].forwardFriction = 20;
				wheels [2].forwardFriction = 10;
				wheels [3].forwardFriction = 10;



			} else {
				wheels [0].forwardFriction = wheelFriction;
				wheels [1].forwardFriction = wheelFriction;
				wheels [2].forwardFriction = wheelFriction1;
				wheels [3].forwardFriction = wheelFriction1;

			}

	





		if (this.GetComponent<Rigidbody> ().velocity.magnitude < 8) {
				if (this.gameObject.tag != "Player2")
					engine.gameObject.GetComponent<GasMotor> ().power = 5f;
				else {

					engine.gameObject.GetComponent<GasMotor> ().power = 8f;


			
				}

			} else {
				if (this.gameObject.tag == "Player2") {
					engine.gameObject.GetComponent<GasMotor> ().power = value;
			
				}
			}

	}
	void OnCollisionStay(Collision collision)
	{
		if(UserPrefs.currentEpisode==1&&UserPrefs.currentLevel==1)
			UserPrefs.PersonKilled=true;


		if (collision.gameObject.GetComponent<EnemyCar> () && Time.time > time + 0.1f&&this.GetComponent<Rigidbody> ().velocity.magnitude < 8) {
			collision.gameObject.GetComponent<Rigidbody> ().mass = Constants.enemyMass;


		}



		else if (collision.gameObject.tag == "Player2"&& Time.time > time + 0.1f&&Mathf.Abs(engine.GetComponent<GasMotor>().targetDrive.feedbackRPM)>300) {
			//&&player.GetComponent<EnginePowerManager>().engine.GetComponent<GasMotor>().targetDrive.feedbackRPM<1000
			collision.gameObject.GetComponent<Rigidbody> ().mass = Constants.playerMass;
		}


	}
	void OnCollisionExit(Collision collision) {
		//		foreach (ContactPoint contact in collision.contacts) {
		//			Debug.DrawRay(contact.point, contact.normal, Color.white);
		//		}
		//		if (collision.relativeVelocity.magnitude > 2)
		//			audio.Play();
		if(UserPrefs.currentEpisode==1&&UserPrefs.currentLevel==1)
			UserPrefs.PersonKilled=false;
		if (collision.gameObject.GetComponent<EnemyCar> ()) {
			this.GetComponent<Rigidbody> ().mass = mass;
			
			
		} else
			if (collision.gameObject.tag == "Player2") {
			this.GetComponent<Rigidbody> ().mass = mass;

		}

		//		
	}
	void OnCollisionEnter(Collision collision) {
		//		foreach (ContactPoint contact in collision.contacts) {
		//			Debug.DrawRay(contact.point, contact.normal, Color.white);
		//		}
		//		if (collision.relativeVelocity.magnitude > 2)
		//			audio.Play();


		time = Time.time;

		if (this.GetComponent<Rigidbody> ().velocity.magnitude > 8) {
			if(collision.gameObject.GetComponent<EnemyCar>())
				collision.gameObject.GetComponent<Rigidbody>().mass=2000;
		}

		//		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Water") {
			Vector3 pos=new Vector3(this.transform.position.x,other.gameObject.transform.position.y,this.transform.position.z);
		//	BoxCollider box=	other.gameObject.GetComponent<BoxCollider>();
		//	box.enabled=false;
			GameObject obj= Instantiate(Resources.Load("Jump Water"),pos,Quaternion.identity)as GameObject;
			if(UserPrefs.isSound)
			{
				SoundManager.Instance.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.waterSplashSound);
			}
		//	obj.SetActive(false);
		//	box.enabled=true;
		}
		else if(other.name == "CFD"&&this.tag=="Player2")//disable smoothfollow
		{
		//	other.gameObject.GetComponent<BoxCollider>().enabled= false;
			Camera.main.GetComponent<SmoothFollow>().target = null;

		}
	}

	public	void ragDollActivator()
	{
		Character.SetActive (false);

		Ragdoll.SetActive (true);
	}

}
