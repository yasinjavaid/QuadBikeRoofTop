using UnityEngine;
using System.Collections;

public class LevelcomleteAnimation : MonoBehaviour {

	// Use this for initialization
	public GameObject followObject;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnEnable()
	{
		GameObject player=	GameObject.FindGameObjectWithTag ("Player2");
		player.AddComponent<FollowAI> ().resetReverseCount = -1;
		player.GetComponent<FollowAI> ().target = followObject.transform;


	}

}
