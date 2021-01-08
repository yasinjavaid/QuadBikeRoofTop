using UnityEngine;
using System.Collections;

public class BlockageSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject[] Blockage;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void disableAllBlockage()
	{
		foreach (GameObject blocks in Blockage) {

			blocks.SetActive(false);

		}



	}
}
