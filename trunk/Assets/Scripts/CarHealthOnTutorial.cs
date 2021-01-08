using UnityEngine;
using System.Collections;

public class CarHealthOnTutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		Debug.Log (col.name);
		if (col.gameObject.name == "Body") {
			//col.GetComponentInParent<Rigidbody>().isKinematic = true;
			GameObject []cars = GameObject.FindGameObjectsWithTag("Player");
			foreach(GameObject c in cars)
			{
				c.GetComponentInParent<RacerControl>().totalHealth = 15f;
			}
			col.GetComponentInParent<RacerControl>().totalHealth = 5f;
			this.gameObject.GetComponent<Collider>().enabled = false;
//			IRDSStatistics.SetCanRace (false);
			//StartCoroutine(ShowInstructions());
			//GameObject.FindObjectOfType<Instructions>().startInstruction.SetActive(true);
		}
	}
	IEnumerator ShowInstructions()
	{
		yield return new WaitForSeconds (0.5f);
		//GameObject.FindGameObjectWithTag ("Player2").GetComponent<Rigidbody> ().isKinematic = true;
		//GameObject.FindObjectOfType<Instructions>().startInstruction.SetActive(true);
		yield return new WaitForSeconds (1f);
		//GameObject.FindGameObjectWithTag ("Player2").GetComponent<Rigidbody> ().isKinematic = false;
		yield return new WaitForSeconds (1f);
	//	GameObject.FindObjectOfType<Instructions>().startInstruction.SetActive(false);
	}
}
