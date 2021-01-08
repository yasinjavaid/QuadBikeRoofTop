using UnityEngine;
using System.Collections;

public class HurdleTrigger : MonoBehaviour {

	// Use this for initialization
	public GameObject hurdle;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		//Debug.Log("HTt "+col.name);
		if(col.gameObject.tag == "Player2"||col.gameObject.tag == "animCar")
		{
			hurdle.GetComponent<Punch>().playTween();
		}
	}
	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.tag == "Player2"||col.gameObject.tag == "animCar")
		{
			hurdle.GetComponent<Punch>().playTween();
		}
	}
	void OnTriggerExit(Collider col)
	{
		//Debug.Log("HTe "+col.name);
		if(col.gameObject.tag == "Player2"||col.gameObject.tag == "animCar")
		{
			hurdle.GetComponent<Punch>().ResetPosition();
		}
	}
}
