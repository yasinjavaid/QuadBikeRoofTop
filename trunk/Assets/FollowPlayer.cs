using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player)
			return;
	if(player==null)
		{


			player=GameObject.FindGameObjectWithTag("Player2");
			if(player)
			gameObject.GetComponent<FollowAI>().target=player.transform;

		}
	}
}
