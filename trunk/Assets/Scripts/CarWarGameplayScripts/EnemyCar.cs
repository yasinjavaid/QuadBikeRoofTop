using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyCar : MonoBehaviour {

	// Use this for initialization
	public Texture [] textures;
	public Renderer[] body;
	public bool ChangeTex = false;

	FollowAI followAI;
	 Transform []targets;
	public Transform engine;
	List<Transform> alltargets = new List<Transform> ();
	public bool isForDebug = false;
	bool isGoingBacktoCenter = false;
	bool isFallDown = false;
	GameObject player;
	GameObject []wayPoints;
	public static bool isLap = false;
	public static Transform lapFirstPoint;
	static int index;
	Wheel [] wheels;
	float wheelFriction;
	float wheelFriction1;
	bool isInTouchWithPlayer=false;
	static bool isFirst = false;
	GameObject Base;
	void Start () {
		Base = GameObject.FindGameObjectWithTag ("Base");
		wheels=this.GetComponent<VehicleParent>().wheels;
		wheelFriction=wheels[0].forwardFriction;
		wheelFriction1=wheels[2].forwardFriction;
		if(ChangeTex){
			if(!isFirst)
			{
				isFirst = true;
				index = Random.Range(0,5);
			}
			else
			{
				index++;
			}
			int i = Random.Range(0,textures.Length);
			foreach(Renderer r in body)
			r.material.mainTexture = textures[i];
		}
		//Invoke("FindTargets",1f);
	}
	void Update () {
		if(isFallDown && followAI.target.name == "19")
		{
			isFallDown = false;
		}
		if(isGoingBacktoCenter)
		{
			if(Vector3.Distance(this.transform.position,followAI.target.position)<4f)
			{
				DisbaleCenterTarget();
			}
			//Debug.Log("Dista : " + Vector3.Distance(this.transform.position,followAI.target.position));
		}
	}
	public	void FindTargets()
	{
		if(isLap)
		{
			followAI = this.GetComponent<FollowAI>();
			followAI.target = lapFirstPoint;
			Lap.initData();
		}
		else
		{
			followAI = this.GetComponent<FollowAI>();
			EnemyCar []enemies = GameObject.FindObjectsOfType<EnemyCar>();
			wayPoints=GameObject.FindGameObjectsWithTag("WayPoint");

			targets = new Transform[enemies.Length];
			player = GameObject.FindGameObjectWithTag("Player2");
			for(int i=0;i<enemies.Length;i++)
			{
				if(enemies[i].gameObject.GetInstanceID() == this.gameObject.GetInstanceID())
				{
				//	Debug.Log(enemies[i].name+ " " + this.gameObject.name);

					targets[i] = player.transform;
				}
				else
				{
					targets[i] = enemies[i].transform;
				}
				if(isForDebug)
				{
					//Debug.Log(this.gameObject.name+" ^^ "+targets[i].name);
				}
			}
			foreach(Transform t in targets)
			{
				alltargets.Add(t);
				//Debug.Log(this.gameObject.name + " ** " + t.name);
			}
			StartCoroutine("ChangeTargetRandom");
		}
	}
	IEnumerator ChangeTargetRandom()
	{

		yield return new WaitForSeconds(0f);
	a:
		if(!isGoingBacktoCenter && !isFallDown)
		{
		b:
				int RandomNumber=Random.Range(0,100);
			if(RandomNumber<Constants.PlayerFollowingProbablity[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1])
			{
				if(player)
				followAI.target = player.transform;
			}
			else if (wayPoints.Length>0&&RandomNumber<Constants.PlayerFollowingProbablity[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1]+Constants.WaypointProbablity[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1])
			{
				int randomWayPoint=Random.Range(0,wayPoints.Length);
				followAI.target=wayPoints[randomWayPoint].transform;

			}
			else
			{
				int index = Random.Range(0,alltargets.Count);
				Transform t = (Transform)alltargets[index];
				if(t == null)
				{
					alltargets.RemoveAt(index);
					goto b;
				}

			
				if(t.gameObject.tag!="Player2")
				{

					Transform tempTarget = t.gameObject.GetComponent<FollowAI>().target;
					if(followAI.target!=null && tempTarget!=null){
					//Debug.Log("****************** "+t.gameObject.GetComponent<FollowAI>().target.name+" "+followAI.target.gameObject.name);
						if(t.gameObject.GetComponent<FollowAI>().target.gameObject.GetInstanceID() == this.gameObject.GetInstanceID())
						{
//							Debug.Log("******************");
							goto b;
						}
						else
						{
							followAI.target = t;
						}
					}
					else
					{
						followAI.target = t;
					}
				}
				else
				{
					followAI.target = t;
				}
			}
		}
		//Debug.Log(this.gameObject.name + " Target  :  "+followAI.target.name);
		yield return new WaitForSeconds(Random.Range(5,10));
		goto a;
	}
	void OnCollisionStay(Collision collisionInfo)
	{
		if (collisionInfo.gameObject.tag == "Player2") {

			isInTouchWithPlayer=true;
		}

	}
	void OnCollisionExit(Collision collisionInfo)

	{
		if (collisionInfo.gameObject.tag == "Player2") {
			isInTouchWithPlayer=false;
		}


	}
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.name == "Base"&&!isInTouchWithPlayer&&followAI)
		{
			//Debug.Log("DIS :   "+Vector3.Distance(this.gameObject.transform.position,col.gameObject.transform.position));

			followAI.speed=0.001f;

			for(int i =0;i<300;i++)
			{
				GetComponent<VehicleParent>().SetEbrake(1);

			}

			followAI.target = Base.transform;
			isGoingBacktoCenter = true;

		//	Invoke("DisbaleCenterTarget",4f);

		}
	}
	void DisbaleCenterTarget()
	{
		isGoingBacktoCenter = false;
		followAI.speed=0.7f;
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "floor") {

			engine.GetComponent<Motor> ().health = 0.2f;
//			GameObject p1 = GameObject.Find ("pointa0");
//			GameObject p2 = GameObject.Find ("pointb0");
//
//			if (!isFallDown) {
//				engine.GetComponent<Motor> ().health = 0.84f;
//				isFallDown = true;
//				if (Random.Range (0, 2) == 0) {
//					this.transform.position = p1.transform.position;
//					this.transform.rotation = p1.transform.rotation;
//					followAI.target = p1.transform;
//				} else {
//					this.transform.position = p2.transform.position;
//					this.transform.rotation = p2.transform.rotation;
//					followAI.target = p2.transform;
//				}
				
			}

		}


}
