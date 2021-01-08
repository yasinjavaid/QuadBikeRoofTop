using UnityEngine;
using System.Collections;

public class TireSpikeEnabler : MonoBehaviour {

	// Use this for initialization
	public GameObject []parts;
	void Start () {
	foreach(GameObject g in parts)
			g.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
