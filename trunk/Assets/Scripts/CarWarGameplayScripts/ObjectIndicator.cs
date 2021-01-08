using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ObjectIndicator : MonoBehaviour {
	
	// Use this for initialization
	public Transform playerindicator;
	public Transform [] enemyIndicator;
	bool isInitialized  = false;
	
	List<EnemyCar>  enemies=new List<EnemyCar>();
	GameObject playerObj;
	
	void Start () {
		Invoke("init",1);
		playerindicator.gameObject.SetActive(false);
		foreach(Transform t in enemyIndicator)
		{
			t.gameObject.SetActive(false);
		}
	}
	public void addNewEnemy(EnemyCar C )
	{
		enemies.Add (C);
		
	}
	public void init()
	{
		EnemyCar[] t = GameObject.FindObjectsOfType<EnemyCar>();
		foreach (EnemyCar G in t) {
			enemies.Add(G);
			
		}
		playerObj = GameObject.FindGameObjectWithTag("Player2");
		isInitialized = true;
		
	}
	// Update is called once per frame
	void Update () {
		if(isInitialized)
		{
			
			if(playerObj!=null)
			{
				playerindicator.gameObject.SetActive(true);
				playerindicator.transform.position  = new Vector3(playerObj.transform.position.x,playerindicator.transform.position.y,playerObj.transform.position.z);
				playerindicator.transform.eulerAngles = new Vector3(0,playerObj.transform.eulerAngles.y,0);
			}
			else
				playerObj = GameObject.FindGameObjectWithTag("Player2");
			for(int i = 0;i<enemies.Count;i++)
			{
				if(enemies[i]!=null){
					enemyIndicator[i].gameObject.SetActive(true);
					enemyIndicator[i].transform.position = new Vector3(enemies[i].transform.position.x,enemyIndicator[i].transform.position.y,enemies[i].transform.position.z);
					enemyIndicator[i].transform.eulerAngles = new Vector3(0,enemies[i].transform.eulerAngles.y,0);
				}
				else
				{
					enemyIndicator[i].gameObject.SetActive(false);
				}
			}
		}
	}
}
