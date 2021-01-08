using UnityEngine;
using System.Collections;

public class ArrestController : MonoBehaviour {
//	public enum CharacterType
//	{
//		THIEF,POLICE
//	}
//	public float speed;
//	float value;
//	public Transform[] transformArray;
//	private bool isToMove = false;
//	private Animator animatorContoller;
//	public int currentWaypoint = 0;
//	public CharacterType characterType;
//	public GameObject droppingPoint;
//	public static bool isInstructionShown = false;
//	public bool IsToMove {
//		get {
//			return this.isToMove;
//		}
//		set {
//			isToMove = value;
//		}
//	}
//	void OnEnable () {
//		animatorContoller = this.GetComponent<Animator>();
//		if(characterType == CharacterType.POLICE)
//		{
//			speed = Constants.thiefSpeed/1.5f;
//			value = 0.4f;
//		}
//		else{
//			speed = Constants.thiefSpeed/1.5f;
//			value = 0.5f;
//		}
//	}
//	// Use this for initialization
//	void Start () {
//		this.transformArray [0] = GameObject.FindGameObjectWithTag ("Player2").transform;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//
//	
//	}
//	void LateUpdate()
//	{
//		if(isToMove)
//			Move (this.transformArray[this.currentWaypoint]);
//	}
//	public void Move (Transform waypoint)
//	{
//		animatorContoller.SetFloat ("value",value);
//			Transform tempVector   = waypoint;
//			Vector3 RelativeWaypointPosition  = transform.InverseTransformPoint( new Vector3(tempVector.position.x,transform.position.y,tempVector.position.z ) );
//			GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*speed );
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
//			
//		}
//	void OnCollisionEnter(Collision collision) {
//		
//		if (collision.gameObject.tag == "Player2") {
//			if(WheelControllerGeneric.isThiefOnBoard)
//			{
//				TutorialManagerNew.Instance.ChangeState(TutorialManagerNew.TutorialState.DROPTHIEF);
//				this.gameObject.SetActive(false);
//				if(droppingPoint != null)
//					droppingPoint.SetActive(true);
//				WheelControllerGeneric.isDummyState = false;
//				isInstructionShown = true;
////				CarMain.handBrakValue = 0;
//				collision.gameObject.GetComponent<WheelControllerGeneric>().AddPhysics();
//				GameObject.FindGameObjectWithTag("Finish").SetActive(false);
//				//			currentWaypoint++;
////				CarMain.SendInput(collision.gameObject.GetComponent<CarControl>(),false,false);
//			}
//		}
//
//	}
}
