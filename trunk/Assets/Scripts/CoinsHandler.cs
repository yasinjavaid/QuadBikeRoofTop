using UnityEngine;
using System.Collections;

public class CoinsHandler : MonoBehaviour {

//	// Use this for initialization
//	public int currentCoins;
//	public int timeBonus;
//
////	int CoinstoAddOrSub = 500;
//	public int finalCoins;
//	bool addNow = false;
//	bool deductNow = false;
//	int IncreasingFactor =1;
//	int a = 0;
//	GameObject message;
//	public ParticleEmitter coinsEffect;
//	int requiredCash;
//	void Start () {
//		//GetComponent<UILabel> ().text = UserPrefs.totalCoins.ToString();
//
//
//		//currentCoins = UserPrefs.totalCoins;
//		currentCoins = 0;
//		Invoke ("setRequiredCash", 0.00001f);
//
//	}
//	void setRequiredCash()
//	{
//		requiredCash = Constants.RequiredCashPerLevel [UserPrefs.currentEpisode-1, UserPrefs.currentLevel-1];
//		GetComponent<UILabel> ().text = "0"+"/"+ requiredCash.ToString();;
//
//	}
//	// Update is called once per frame
//	void Update () {
//		if(addNow)
//		{
//
//			if(currentCoins < finalCoins)
//				currentCoins += IncreasingFactor;
//			if(currentCoins==finalCoins)
//			{
//				if(currentCoins>=requiredCash)
//				{
//					Invoke("FinishLevel",0.5f);
//				}
//				addNow = false;
//				a=0;
//			}
//			GetComponent<UILabel> ().text = currentCoins.ToString()+" / "+ requiredCash.ToString();
//		}
//		else if (deductNow) {
//			if(currentCoins > finalCoins)
//				currentCoins -= IncreasingFactor;
//			if(currentCoins==finalCoins)
//			{
//				deductNow = false;
//				a=0;
//			}
//			GetComponent<UILabel> ().text = currentCoins.ToString()+" / "+ requiredCash.ToString();
//		}
//	}
//	public void AddCoins(int coins,string msg)
//	{
//		finalCoins = currentCoins+coins;
//		a = 1;
//			//addNow = true;
//		message = GameObject.FindObjectOfType<Messages> ().GetComponent<Messages> ().TaficSignalMessage;
//		message.GetComponent<UILabel> ().text = msg;
//		message.GetComponent<UILabel> ().color = Color.green;
//		Invoke ("EnableEffect", 0.8f);
//
//		message.SetActive (true);
//		Invoke ("DisableMessage", 1.35f);
//	}
//	void EnableEffect()
//	{
//		coinsEffect.emit = true;
//		GameManager.Instance.ChangeState (GameManager.SoundState.COINSADD);	
//		Invoke ("DisableEffect", 1.2f);
//
//	}
//	void DisableEffect()
//	{
//		coinsEffect.emit = false;
//
//	}
//	public void DeductCoins(int coins,string msg)
//	{
//
//		a = 2;
//		finalCoins = currentCoins-coins;
//		//deductNow = true;
//		message = GameObject.FindObjectOfType<Messages> ().GetComponent<Messages> ().TaficSignalMessage;
//		message.GetComponent<UILabel> ().text = msg;
//		message.GetComponent<UILabel> ().color = Color.red;
//
//		message.SetActive (true);
//		Invoke ("DisableMessage", 1.35f);
//	}
//	void DisableMessage()
//	{
//
//		if (a == 1) {
//						//addNow = true;
//			Invoke("AddNowTrue",1.5f);
//				}
//				else if (a == 2) {
//			GameManager.Instance.ChangeState (GameManager.SoundState.COINSDEDUCT);	
//			deductNow = true;
//				}
//		message.SetActive (false);
//	}
//	void AddNowTrue()
//	{
//		addNow = true;
//	}
//	public void SaveCollectedCoins()
//	{
//		if (currentCoins > 0) {
//
//			UserPrefs.totalCoins = UserPrefs.totalCoins+currentCoins+timeBonus;		
//		}
//	}
//	void FinishLevel()
//	{
//		WheelControllerGeneric script = (WheelControllerGeneric) GameObject.FindGameObjectWithTag("Player").transform.GetComponent("WheelControllerGeneric");
//		script.LevelCompleted();
//		
//	}
}
