using UnityEngine;
using System.Collections;

public class TrafficSpawnerListener : MonoBehaviour {
	private GameObject ItsManager;
	private int value;
	public UILabel cars;
	// Use this for initialization
	void Start () {
		ItsManager = GameObject.FindGameObjectWithTag ("ItsManager");
		value=ItsManager.GetComponent<TSTrafficSpawner> ().amount;
		cars.text = value.ToString();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick ()
	{
		if (this.name == "inc") {

			value++;
		}
			else
				value--;

		cars.text = value.ToString();
			if (value > 0)
				ItsManager.GetComponent<TSTrafficSpawner> ().amount = value;

		

	}


}
