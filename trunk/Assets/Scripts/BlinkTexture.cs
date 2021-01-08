using UnityEngine;
using System.Collections;

public class BlinkTexture : MonoBehaviour {

	// Use this for initialization
	public GameObject obj;

	public float timeoff = 0.5f,timeon = 0.5f;


	void Start () {
	}
	void OnEnable()
	{
		StartCoroutine("blink");

	}
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator blink()
	{
	b:
			yield return new WaitForSeconds(timeon);
		obj.GetComponent<Renderer>().enabled =false;
		yield return new WaitForSeconds(timeoff);
		obj.GetComponent<Renderer>().enabled =true;

		goto b;
	}
}
