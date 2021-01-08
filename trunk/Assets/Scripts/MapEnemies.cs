using UnityEngine;
using System.Collections;

public class MapEnemies : MonoBehaviour {

	public GameObject[] enemyIndicators;

	// Use this for initialization
	void Start () {
		Debug.Log("+++++++ MapEnemies start called");
		Invoke ("GetTargets", 2f);
		Debug.Log("+++++++ MapEnemies start end");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void GetTargets()
	{
		for(int i = int.Parse(Constants.totalCars[UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1].ToString()) ; i < enemyIndicators.Length; i++){
			enemyIndicators[i].SetActive(false);
		}
		
		var enemies = GameObject.FindGameObjectsWithTag("Player");
		for(int i = 0 ; i < enemies.Length; i++){
			enemyIndicators[i].GetComponent<MapHandler>().target = enemies[i].transform;
		}
	}
}
