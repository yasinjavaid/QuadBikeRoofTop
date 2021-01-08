using UnityEngine;
using System.Collections;

public class BodyHandler : MonoBehaviour {

	// Use this for initialization
	private static int hitTimes = 0;
	private GameObject thiefCar;
	void Start () {
		thiefCar = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter (Collision col)
	{
//		Debug.LogError(col.gameObject.name);
//		Debug.LogError(col.gameObject.transform.root.name);
//		Debug.LogError(thiefCar.gameObject.name);
//		if(col.gameObject.name == "Finish")
//		{
//			hitTimes++;
//			Destroy(col.gameObject);
//		}
	}
}
