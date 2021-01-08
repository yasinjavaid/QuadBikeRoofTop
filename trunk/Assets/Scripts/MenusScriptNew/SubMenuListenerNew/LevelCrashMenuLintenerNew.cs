using UnityEngine;
using System.Collections;

public class LevelCrashMenuLintenerNew : MonoBehaviour {
	GameObject btnContinue;
	public UILabel speedBonus,distanceBonus,totalCash;
	// Use this for initialization  btnContinueOnCrash
	void Start () {
		btnContinue  =	GameObject.FindGameObjectWithTag("btnContinueOnCrash");
		if (this.name.Equals ("btnContinue")) {
			//var stats = GameObject.FindObjectOfType<VehicleStats>().GetComponent<VehicleStats>();
			int a = Random.Range(30,50);
			int b = Random.Range(30,70);
			distanceBonus.text = a.ToString(); //Mathf.CeilToInt(stats.Distance)*50).ToString();
			speedBonus.text = b.ToString();//((int)stats.ModeMaxSpeed).ToString();
			int totalEarnecCash = a+b;//(Mathf.CeilToInt(stats.Distance)*50)+(int)stats.ModeMaxSpeed;
			GameManager.Instance.AddCoins(totalEarnecCash);
			totalCash.text = totalEarnecCash.ToString();
			
//			playAnimationOnLabels();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnClick(){
		if(this.name.Equals("btnContinue")){
			GameManager.Instance.ChangeState(GameManager.GameState.SHOWAD);
			UserPrefs.adCounter++;
			Debug.Log("btnContinue Pressed");
			SoundManager.Instance.vehicleEngineSoundSource.volume = 0.0f;
			Destroy(GameObject.FindGameObjectWithTag("LevelCrash"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLEUPGRADEMENU);
			Application.LoadLevel("MenusScene");
			//MenuManager.Instance.StartNewMenus();
			//Uncomment during final integration
			
			Time.timeScale=1;
		}
		if (this.name.Equals ("btnRetry")) {
			UserPrefs.Save();
			Time.timeScale = 1;
			Resources.UnloadUnusedAssets();
			Destroy(GameObject.FindGameObjectWithTag("levelPause"));
			Destroy(GameObject.FindGameObjectWithTag("Hud"));
			Resources.UnloadUnusedAssets();
			//			GameManager.Instance.ChangeState(GameManager.GameState.SHOWAD);
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LOADING);
			StartCoroutine(MenuManager.Instance.LoadScene(1));
		}
	}
}
