using UnityEngine;
using System.Collections;

public class PoliceChaserCollider : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		player = GameObject.FindGameObjectWithTag ("Player2");
		if (other.gameObject.tag =="PoliceCar") {

			other.gameObject.GetComponent<FollowAI>().target=player.transform;

		}
	}
}
