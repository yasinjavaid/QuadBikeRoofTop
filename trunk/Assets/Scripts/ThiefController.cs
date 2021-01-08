using UnityEngine;
using System.Collections;

public class ThiefController : MonoBehaviour {
//	public enum ThiefPose
//	{
//		IDLE,
//		WALK,
//		RUN,
//		HIT
//
//	}
//	public enum LevelType
//	{
//		DELIEVER,
//		ARREST,
//		BRIEFCASE
//	}
//
//	private Animator animatorContoller;
//	public Transform[] transformArray;
//	int currentWaypoint = 0;
//	private float thiefSpeed;
//	public ThiefPose thiefPose;
//	public LevelType levelType;
//	private bool canChangePath = true;
//	private float changeTime = 3.0f;
//	bool levelFinished = false;
//	private float timer = 0;
//	// Use this for initialization
//	void OnEnable () {
//		animatorContoller = this.GetComponent<Animator>();
//		if (levelType == LevelType.ARREST || levelType == LevelType.BRIEFCASE) {
//			GameObject.FindGameObjectWithTag("Thief").GetComponent<ArrestController>().enabled = false;
//		}
//		else{
//			this.enabled = false;
//		}
//	}
//	void Start () {
//		thiefPose = ThiefPose.IDLE;
//		animatorContoller.SetFloat ("value",0f);
//		if(levelType == LevelType.BRIEFCASE)
//		{
//			this.thiefPose = ThiefPose.RUN;
//		}
//
//		timer = Time.time;
//	}
//	void LateUpdate()
//	{
//		Move (this.transformArray[this.currentWaypoint]);
//	}
//	// Update is called once per frame
//	void Update () {
//		if(!levelFinished && Time.time > timer+Constants.thiefChaseTime)
//		{
//			GameObject.FindGameObjectWithTag("Player2").GetComponent<WheelControllerGeneric>().LevelFailed();
//			levelFinished = true;
//		}
//		if(thiefPose != ThiefPose.HIT && levelType == LevelType.ARREST)
//		{
////			if(CalculateDistance() > 15)
////			{
////				thiefPose = ThiefPose.IDLE;
////			}
////			 if(CalculateDistance() < 30)
////			{
////				thiefPose = ThiefPose.WALK;
////			}
//			if(CalculateDistance() < 30)
//			{
//				thiefPose = ThiefPose.RUN;
////				if(!UserPrefs.isTutorial && !ArrestController.isInstructionShown)
////				{
////					TutorialManager.Instance.ChangeState(TutorialManager.TutorialStates.THIEFINAPPRACH);
////					ArrestController.isInstructionShown = true;
////				}
//				if(!UserPrefs.isArrestThiefTutorialCompleted && !ArrestController.isInstructionShown){
//					ArrestController.isInstructionShown = true;
//
//				}
//			}
////			if(CalculateDistance() < 20)
////			{
////
////			}
//			
//			if(CalculateDistance() < 10)
//			{
//				
//				changeWayPoint();
//			}
//		}
//	}
//	float CalculateDistance()
//	{
//		float minDist= Vector3.Distance(GameObject.FindGameObjectWithTag("Police").gameObject.transform.position,this.gameObject.transform.position);
//		return minDist;
//	}
//
//	float CalculateDistanceWithPlayer()
//	{
//		float minDist= Vector3.Distance(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position,this.gameObject.transform.position);
//		return minDist;
//	}
//	public void changeWayPoint()
//	{
//		if(canChangePath){
////			if(currentWaypoint < transformArray.Length){
//				this.currentWaypoint ++;
//				currentWaypoint = currentWaypoint % transformArray.Length;
//				canChangePath = false;
//				StartCoroutine(waitToChangeNextWayPoint());
//				Debug.LogError("Path has been changed");
////			}
//		}
//	}
//	IEnumerator waitToChangeNextWayPoint()
//	{
//		yield return new WaitForSeconds (changeTime);
//		canChangePath = true;
//	}
//	public void Move (Transform waypoint)
//	{
//		if(thiefPose != ThiefPose.HIT)
//		{
//			if(thiefPose == ThiefPose.IDLE )
//			{
//				animatorContoller.SetFloat ("value",0f);
//				thiefSpeed = 0;
//			}
//			else if(thiefPose == ThiefPose.WALK)
//			{
//				animatorContoller.SetFloat ("value",0.5f);
//				thiefSpeed = Constants.thiefSpeed/3;
//			}
//			else if(thiefPose == ThiefPose.RUN)
//			{
//				animatorContoller.SetFloat ("value",1f);
//				thiefSpeed = Constants.thiefSpeed;
//				if(levelType == LevelType.ARREST)
//					thiefSpeed = Constants.thiefSpeed+25;
//			}
//			Transform tempVector   = waypoint;
//			Vector3 RelativeWaypointPosition  = transform.InverseTransformPoint( new Vector3(tempVector.position.x,transform.position.y,tempVector.position.z ) );
//			GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*thiefSpeed );
//			GetComponent<Rigidbody>().AddTorque(0f,( (RelativeWaypointPosition.x)/RelativeWaypointPosition.magnitude)*15.0f, 0f, ForceMode.VelocityChange);
//			//	force = new Vector3(transform.forward.x, 0f, transform.forward.z) * motor_max * joyStick.position.y*2;
//			//rigidbody.ad((new Vector3(transform.forward.x, 0f, transform.forward.z) * 2 * (RelativeWaypointPosition.z/RelativeWaypointPosition.magnitude-Mathf.Abs( (RelativeWaypointPosition.x)/RelativeWaypointPosition.magnitude ))) * Time.deltaTime, ForceMode.VelocityChange);
//			
//			transform.LookAt(this.transformArray[this.currentWaypoint].transform);
//			Quaternion.LookRotation(this.transformArray[this.currentWaypoint].transform.position-transform.position);
//			//Debug.LogError("@@@@@@@@@@@@@@@@@@@  "+this.currentWaypoint);
//			float distance=Vector3.Distance(this.transformArray[this.currentWaypoint].transform.position,this.gameObject.transform.position);
//			//Debug.LogError("@@@@@@@@@@@@@@@@@@@  "+distance);
//			
//			if(distance<3) //this.currentWaypoint<(this.transformArray.Length-1) &&
//			{
//				this.currentWaypoint++;
//				//			Debug.LogError("this.currentWaypoint = "+this.currentWaypoint);
//				//Debug.LogError("array length  = "+this.this.transformArray.Count);
//				if(this.currentWaypoint>=(this.transformArray.Length))
//				{
//					currentWaypoint = 0;
//				}
//			}
//
//		}
//	}
//
//	void OnCollisionEnter(Collision collision) {
//		if(!levelFinished && Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1]!=2)
//		{
//			if (collision.gameObject.tag == "Police") {
//				if(levelType == LevelType.ARREST)
//				{
//					animatorContoller.SetBool("isHit",true);
//					thiefPose = ThiefPose.HIT;
//					StartCoroutine(playThiefHitSound());
//					this.GetComponent<Rigidbody>().isKinematic = true;
//					this.GetComponent<CapsuleCollider>().enabled = false;
//					var pos = this.gameObject.transform.position;
//					this.gameObject.transform.position= new Vector3(pos.x,pos.y+0.2f,pos.z);
//					this.transform.root.GetComponent<LevelHandlerGeneric>().NextLevel();
//					levelFinished = true;
//				}
//			}
//			else if(collision.gameObject.tag == "Player2")
//			{
//				animatorContoller.SetBool("isHit",true);
//				this.GetComponent<Rigidbody>().isKinematic = true;
//				StartCoroutine(playThiefHitSound());
//				this.GetComponent<CapsuleCollider>().enabled = false;
//				var pos = this.gameObject.transform.position;
//				this.gameObject.transform.position= new Vector3(pos.x,pos.y+0.2f,pos.z);
//				StartCoroutine(setPlayerAfterHit());
//				TutorialManagerNew.Instance.ShowInfoPanel("Get out of the car and take him down");
//				//thiefPose = ThiefPose.HIT;
//			}
////			else if(collision.gameObject.tag == "Target")
////			{
////				GameObject.FindGameObjectWithTag("Player2").GetComponent<WheelControllerGeneric>().LevelFailed();
////				levelFinished = true;
////			}
//		}
//
//	}
//	IEnumerator setPlayerAfterHit()
//	{
//		yield return new WaitForSeconds (3f);
//		animatorContoller.SetBool("isHit",false);
//		this.GetComponent<Rigidbody>().isKinematic = false;
//		this.GetComponent<CapsuleCollider>().enabled = true;
//
//	}
//	IEnumerator playThiefHitSound()
//	{
//		GameManager.Instance.ChangeState (GameManager.SoundState.THIEFCRYING);
//		yield return new WaitForSeconds (0.5f);
//		GameManager.Instance.ChangeState (GameManager.SoundState.THIEFFALL);
//	}
}
