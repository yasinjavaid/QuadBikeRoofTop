using UnityEngine;
using System.Collections;

public class PoliceLights : MonoBehaviour {

	// Use this for initialization
	BoxCollider box;
	void Start () {
		
		box = GetComponent<BoxCollider>();
		StartCoroutine(Lights());
	}
	
	// Update is called once per frame
	void Update () {
	}
	IEnumerator Lights()
	{
	l:
		yield return new WaitForSeconds(Random.Range(0.1f,0.5f));
		box.enabled = true;
		yield return new WaitForSeconds(Random.Range(0.1f,0.5f));
		box.enabled = false;
		goto l;
	}

}
