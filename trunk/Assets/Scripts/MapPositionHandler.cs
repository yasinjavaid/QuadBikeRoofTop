using UnityEngine;
using System.Collections;

public class MapPositionHandler : MonoBehaviour {
	public enum MapObjectsType
	{
		CAR,
		POLICE,
		THIEF,
		REDTHIEF,
		BREIFCASE,
		CHECKPOINT
	}
	// Use this for initialization
	public GameObject selfObject;
	public GameObject targetObject;
	GameObject map;
	public MapObjectsType mapObjectType;
	bool isTargetSet = false;
	void Start () {
		selfObject = this.gameObject;
		setTarget ();
		map = GameObject.FindGameObjectWithTag ("Map");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void LateUpdate () 
	{
		if(isTargetSet)
		{
			targetObject.transform.position = new Vector3(selfObject.transform.position.x, this.transform.position.y, selfObject.transform.position.z);
		}
	}
	public void setTarget()
	{
		if(mapObjectType == MapObjectsType.CAR)
		{
			targetObject = GameObject.Find("TargetCar");
			targetObject.GetComponent<Renderer>().enabled = true;
			isTargetSet = true;
		}
		else if(mapObjectType == MapObjectsType.POLICE)
		{
			setTargetWithString("TargetPolice");
			
		}
		else if(mapObjectType == MapObjectsType.THIEF)
		{
			targetObject = GameObject.Find("TargetPolice");
			targetObject.GetComponent<Renderer>().enabled = true;
			isTargetSet = true;
		}
		else if(mapObjectType == MapObjectsType.BREIFCASE)
		{
			targetObject = GameObject.Find("TargetPolice");
			targetObject.GetComponent<Renderer>().enabled = true;
			isTargetSet = true;
		}
		else if(mapObjectType == MapObjectsType.CHECKPOINT)
		{
			targetObject = GameObject.Find("TargetPolice");
			targetObject.GetComponent<Renderer>().enabled = true;
			isTargetSet = true;
		}
		else if(mapObjectType == MapObjectsType.REDTHIEF)
		{
			targetObject = GameObject.Find("TargetPolice");
			targetObject.GetComponent<Renderer>().enabled = true;
			isTargetSet = true;
		}
		
	}

	void setTargetWithString(string objectName)
	{
		targetObject = GameObject.Find(objectName);
		targetObject.GetComponent<Renderer>().enabled = true;
		isTargetSet = true;
	}

}
