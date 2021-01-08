using UnityEngine;
using System.Collections;

[RequireComponent (typeof(TSTrafficSpawner))]
public class TrafficSpawner : MonoBehaviour {

	TSTrafficSpawner _mTrafficSpawner;

	void Awake(){
		_mTrafficSpawner = this.GetComponent<TSTrafficSpawner> ();
		_mTrafficSpawner.amount = Random.Range (5, 10);
//		StartCoroutine (DelayForNoDamage ());
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	IEnumerator DelayForNoDamage(){
//		yield return new WaitForSeconds(3);
//		var damage = GameObject.FindGameObjectWithTag ("NoDemage");
//		if(damage)
//			_mTrafficSpawner.amount = Random.Range (2, 5);
//	}
}
