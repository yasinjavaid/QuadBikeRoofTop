using UnityEngine;
using System.Collections;

public class LevelHandlerGeneric : MonoBehaviour {

//	public GameObject [] subLevels;
//	public int currentSubLevel = 0;
//	// Use this for initialization
//	void Start () {
//		subLevels[0].SetActive(true);
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
//	public void NextLevel(){
//		currentSubLevel++;
//		if(currentSubLevel == subLevels.Length){
//			GameObject.FindGameObjectWithTag("Player2").GetComponent<WheelControllerGeneric>().LevelCompleted();
//			return;
//		}
//
//		GameManager.Instance.ChangeState(GameManager.GameState.LEVELCONTINUE);
//	}
//
//	public void InstantiateNextLevel(){
//		subLevels[currentSubLevel - 1].SetActive(false);
//		subLevels[currentSubLevel].SetActive(true);
//	}
}
