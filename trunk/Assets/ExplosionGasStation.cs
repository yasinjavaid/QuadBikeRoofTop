using UnityEngine;
using System.Collections;

public class ExplosionGasStation : MonoBehaviour {
	public GameObject fire;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "Player2") {
			explosion.SetActive(true);

			StartCoroutine(fire1());
			Destroy(explosion,2.0f);
		}
	}
	IEnumerator fire1()
	{
		yield return new WaitForSeconds(1.0f);
		fire.SetActive (true);
		Destroy (fire, 5.0f);

	}
}
