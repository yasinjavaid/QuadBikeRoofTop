using UnityEngine;
using System.Collections;

public class NoDemage : MonoBehaviour {
	public float requiredTime;
	static float timer;
	// Use this for initialization
	void Start () {
		timer = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > timer+requiredTime)
		{
			GameObject.FindGameObjectWithTag("Player2").GetComponent<WheelControllerGenericNew>().levelCompleted(1);
		}
	
	}
}
