using UnityEngine;
using System.Collections;

public class CounterAnimation : MonoBehaviour {

	public GameObject background;
	int counter = 3;
	public GameObject playerAudio;
	// Use this for initialization
	void Start () {
		//GameManager.Instance.ChangeState(GameManager.GameState.COUNTER);
		playerAudio = GameObject.FindWithTag ("PlayerAudio");
		if(playerAudio != null && !UserPrefs.isSound)
			playerAudio.SetActive(false);
		this.GetComponent<UILabel>().text = counter.ToString();
		Invoke ("AnimateCounter", 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void DisablePlayerAudio()
	{
		if(playerAudio != null)
			playerAudio.SetActive(false);
	}
	public void EnableAudio()
	{
		if(playerAudio != null)
			playerAudio.SetActive(true);
	}
	void AnimateCounter(){
		//background.SetActive (true);
		//this.GetComponent<UILabel> ().enabled = true;
		iTween.ScaleFrom(this.gameObject, iTween.Hash("x" , 20 , "y" , 20 , "time" , 1, "isLocal", true, "easeType" , iTween.EaseType.linear, "onComplete", "DecreaseCounter"));
	}

	void DecreaseCounter(){
		counter--;
		this.GetComponent<UILabel>().text = counter.ToString();
		if(counter <= 0){
			this.GetComponent<UILabel>().text = "GO!";
			GameManager.Instance.ChangeState(GameManager.SoundState.POLICESIREN,GameManager.GameState.GAMEPLAY);
			//if(playerAudio != null)
			//	playerAudio.SetActive(true);
			StartCoroutine(DestroyCounter());
			return;
		}
		AnimateCounter();
	}

	IEnumerator DestroyCounter(){
		yield return new WaitForSeconds(1);
		this.transform.root.GetComponentInChildren<UIPanel>().alpha = 0;
		if(!UserPrefs.isTutorialFinished){
			yield return new WaitForSeconds(0.5f);
			GameManager.Instance.ChangeState(GameManager.GameState.PICKPASSENGERINSTRUCTIONS);
		}
	}
}
