using UnityEngine;
using System.Collections;

public class PropsIlluminAnimation : MonoBehaviour {

	public Shader dim;
	public Shader bright;

	// Use this for initialization
	void Start () {
		StartCoroutine(Animate ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Animate(){
		while(true){
			yield return new WaitForSeconds(0.75f);
			this.gameObject.GetComponent<Renderer>().material.shader = bright;
			yield return new WaitForSeconds(0.75f);
			this.gameObject.GetComponent<Renderer>().material.shader = dim;
		}
	}
}
