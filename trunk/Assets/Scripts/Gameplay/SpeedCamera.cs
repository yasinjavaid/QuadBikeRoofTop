using UnityEngine;
using System.Collections;
using System.IO;

public class SpeedCamera : MonoBehaviour {

	public GameObject screenShotCamera;
	public SpriteRenderer sprite;
	public float targetSpeed = 50;
	public UILabel lblTargetSpeed;

	public static float currentCameraSpeed = 0;

	void Awake(){
		if (!UserPrefs.isIncreaseDifficulty [UserPrefs.currentLevel - 1])
			return;

		targetSpeed = UserPrefs.currentSpeedCameraTargetSpeed + (UserPrefs.currentSpeedCameraTargetSpeed * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO);
		UserPrefs.currentSpeedCameraTargetSpeed = targetSpeed;
		UserPrefs.isIncreaseDifficulty [UserPrefs.currentLevel - 1] = false;
	}

	// Use this for initialization
	void Start () {
		currentCameraSpeed = 0;
		lblTargetSpeed.text = string.Format ("{0:00} KM/H" , targetSpeed);
		GAManager.Instance.LogDesignEvent("ModeStart::Episode"+UserPrefs.currentEpisode+"::SpeedCameras");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void  OnTriggerEnter (Collider collisionInfo){
		if (collisionInfo.transform.root.CompareTag("Player2")) {
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
			try{
			Camera.main.GetComponent<BloomAndLensFlares>().enabled = true;
			}catch(System.Exception ex){
				Debug.Log(ex);
			}
			StartCoroutine(DisableBloom());
		}
	}

	IEnumerator DisableBloom(){
		yield return new WaitForSeconds (0.3f);
		try{
		Camera.main.GetComponent<BloomAndLensFlares>().enabled = false;
		}catch(System.Exception ex){
			Debug.Log(ex);
		}
		GameObject.FindObjectOfType<HudStatus> ().ShowSpeedCameraLabel (true);

//		yield return new WaitForSeconds (0.2f);
//		try{
//		string path = "";
//#if UNITY_EDITOR
//		path = "screenshot.jpg";
//#else
//		path = Application.persistentDataPath + "/screenshot.jpg";
//#endif
//		Application.CaptureScreenshot(path);
////		yield return new WaitForEndOfFrame();
//		var texture = new Texture2D (4, 4);
//		var file = File.ReadAllBytes (path);
//		texture.LoadImage (file);
//		sprite.sprite = Sprite.Create (texture, new Rect(0, 0, Screen.width, Screen.height),new Vector2(0.5f,0.5f));
//		}catch(System.Exception ex){
//			Debug.Log(ex);
//		}
			
		yield return new WaitForSeconds (0.5f);
//		screenShotCamera.SetActive (true);
		GameObject.FindObjectOfType<HudStatus> ().ShowSpeedCameraLabel (false);

		if (currentCameraSpeed >= targetSpeed) {
			GAManager.Instance.LogDesignEvent("ModeComplete::Episode"+UserPrefs.currentEpisode+"::SpeedCameras");
			GameObject.FindObjectOfType<WheelControllerGenericNew>().levelCompleted(3);

		} else {
			GameObject.FindObjectOfType<WheelControllerGenericNew>().levelFailed(3);
		}
	}
}
