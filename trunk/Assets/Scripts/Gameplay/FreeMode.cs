using UnityEngine;
using System.Collections;

public class FreeMode : MonoBehaviour {
	public GameObject[] carPositions;

	// Use this for initialization
	void Start () {
		enableCarPosition ();
		GAManager.Instance.LogDesignEvent("ModeStart::Episode"+UserPrefs.currentEpisode+"::FreeRide");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void enableCarPosition()
	{

		carPositions[Random .Range(0,carPositions.Length)].SetActive(true);

	}
}
