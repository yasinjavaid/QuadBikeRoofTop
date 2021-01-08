/* 	Author: Zaki Imtiaz
 * 	Date: August 2015
 * 
 *  Intro: Cross Promotion Manager serves as the manager whoes core responsibility is
 *  to download and cache the cross promotion meta data from the server. Relavent Server links 
 *  are to be declared in this class.
 * 
 * 	JSON parser litJSON documentation
 *  http://wiki.unity3d.com/index.php?title=UnityLitJSON
 * 	
 *  ////////CROSS PROMOTION JSON FORMAT//////////////
	
	{
		"refresh_rate": "24",//To be given in number of hours
	
		"promotion1":{
	    	"title"		: "01: test title",
	    	"promo"		: "01: url for promo image to be downloaded",
	    	"text"		: "01: text to b displayed along with the game",
	     	"url"		: "01: url to be taken after the promo is clicked",	
	    	"refID"		: "01: refID for the game"
	  	},
	  	
	  	"promotion2":{
	    	"title"		: "02: test title",
	    	"promo"		: "02: url for promo image to be downloaded",
	    	"text"		: "02: text to b displayed along with the game",
	     	"url"		: "02: url to be taken after the promo is clicked",	
	    	"refID"		: "02: refID for the game"
	  	},
	  	
	  	"promotion3":{
	    	"title"		: "03: test title",
	    	"promo"		: "03: url for promo image to be downloaded",
	    	"text"		: "03: text to b displayed along with the game",
	     	"url"		: "03: url to be taken after the promo is clicked",	
	    	"refID"		: "03: refID for the game"	
	  	}
	}
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using LitJson;
using System.IO;
using PreviewLabs;

namespace CustomCrossPromotions
{
	public class CrossPromotionManager : MonoBehaviour
	{

		/* Events - START */

		// Fired when an interstitial ad is loaded
		public static event Action onCrossPromotionsLoadedEvent;
		
		// Fired when meta file fails to load
		public static event Action onCrossPromotionsMetaFailedEvent;

		//Fired when cross promotional graphics fails to load
		public static event Action onCrossPromotionsDataFailedEvent;

		//Fired when Cross Promotion Manager refreshes all ads (if any new are available at server)
		public static event Action onCrossPromotionRefreshedEvent;

		/* Events - END */


		/*SERVER CONFIGURATION SECTION*/

		//Generic group URL for ANDROID. To be used if group specific cross promotions are not available on the server
		private const string ANDROID_SERVER_ADDRESS_GENERIC = "https://s3.amazonaws.com/tapinator-games-crosspromotion/JSON_CrossPromotionTest_compact-1.txt"; 

		//Android group URL. To be used for android cross promotions
		private const string ANDROID_SERVER_ADDRESS = "https://s3.amazonaws.com/tapinator-games-crosspromotion/JSON_CrossPromotionTest_compact-1.txt";

		//Generic group URL for IOS. To be used if group specific cross promotions are not available on the server
		private const string IOS_SERVER_ADDRESS_GENERIC = "";

		//IOS group URL. To be used for android cross promotions
		private const string IOS_SERVER_ADDRESS = "";

		/*CLIENT CONFIGURATION SECTION*/
		public enum PROMOTION_PROPERTIES
		{
			PROMOTIONAL_METADATA_DOWNLOADED,
			PROMOTIONAL_DATA_DOWNLOADED,
			PROMOTIONAL_METADATA_DOWNLOAD_FAILED,
			PROMOTIONAL_DATA_DOWNLOAD_FAILED
		}

		//TEST JSON
		string _test_jsonToBeParsed = "{\"refresh_rate\":\"24\",\"promotion1\":{\"title\":\"01: test title\",\"promo\":\"01: url for promo image to be downloaded\",\"text\":\"01: text to b displayed along with the game\",\"url\":\"01: url to be taken after the promo is clicked\",\"refID\":\"01: refID for the game\"},\"promotion2\":{\"title\":\"02: test title\",\"promo\":\"02: url for promo image to be downloaded\",\"text\":\"02: text to b displayed along with the game\",\"url\":\"02: url to be taken after the promo is clicked\",\"refID\":\"02: refID for the game\"},\"promotion3\":{\"title\":\"03: test title\",\"promo\":\"03: url for promo image to be downloaded\",\"text\":\"03: text to b displayed along with the game\",\"url\":\"03: url to be taken after the promo is clicked\",\"refID\":\"03: refID for the game\"}}";
//		string _test_jsonToBeParsed02 = "{\"refresh_rate\":\"24\",\"promotion1\":{\"title\":\"Bike Stunts\",\"promo\":\"https://s3.amazonaws.com/tapinator-games-crosspromotion/BikeStunts.png\",\"text\":\"Click here to download Bike Stunts\",\"url\":\"https://play.google.com/store/apps/details?id=com.tapinator.extreme.bike.stunts\",\"refID\":\"com.tapinator.test.crosspromotion\"},\"promotion2\":{\"title\":\"Mini car\",\"promo\":\"https://s3.amazonaws.com/tapinator-games-crosspromotion/MiniCar.png\",\"text\":\"Click here to download Mini Car Driver 3D\",\"url\":\"https://play.google.com/store/apps/details?id=com.tapinator.amazing.mini.driver3d\",\"refID\":\"com.tapinator.test.crosspromotion\"},\"promotion3\":{\"title\":\"School Bus\",\"promo\":\"https://s3.amazonaws.com/tapinator-games-crosspromotion/SchoolBus.png\",\"text\":\"Click here to download Schoolbus Driver\",\"url\":\"https://play.google.com/store/apps/details?id=com.tapinator.schoolbus.driver.sim\",\"refID\":\"com.tapinator.test.crosspromotion\"}}";

		string _jsonToBeParsed = "";
		private CrossPromotion[] _Cross_Promotions;
		private float _refresh_rate = 0f;
		private int totalPromotionsDownloaded = 0;
		public bool test;
		private static readonly DateTime UnixEpoch = new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		private static readonly string filePath = Application.persistentDataPath + "/PromotionsData.txt";

		bool paused {
			get;
			set;
		}

		/*Basic Singleton implementation*/
		private static CrossPromotionManager _instance;
		
		public static CrossPromotionManager instance {
			get {
				if (_instance == null) {
					_instance = GameObject.FindObjectOfType<CrossPromotionManager> ();
					
					//Tell unity not to destroy this object when loading a new scene!
					DontDestroyOnLoad (_instance.gameObject);
				}
				
				return _instance;
			}
		}
		
		void Awake ()
		{
			if (_instance == null) {
				//If I am the first instance, make me the Singleton
				_instance = this;
				DontDestroyOnLoad (this);
			} else {
				//If a Singleton already exists and you find
				//another reference in scene, destroy it!
				if (this != _instance)
					Destroy (this.gameObject);
			}
		}

		void OnApplicationPause (bool pauseStatus)
		{
			paused = pauseStatus;
		}

		void FixedUpdate ()
		{
			if (paused) {
				Debug.Log ("Application resumed. Checking if cross promotions need to be downloaded");
				StartCoroutine (LoadDataFromDisk ());
				paused = false;
			}
		}

		/* Class Level Initialization to be done in init()
		 * */
		void Init ()
		{
			_Cross_Promotions = null;
//			PreviewLabs.PlayerPrefs.setFileName ("CustomCrossPromotionData");
//			test = true;

		}

		// Use this for initialization
		void Start ()
		{
			Init ();
			/* ALGORITHM
			 * 
			 * 01: Check for platform specific URL and try to download JSON
			 * 02: If found, parse.
			 * 03: Else, download generic JSON and parse
			 * 04: After parsing, download the graphics on a different thread and store them on the physical disk*/

			StartCoroutine (LoadDataFromDisk ());

		}

		IEnumerator DownloadFile (string fileURL)
		{

			WWW www;
			if (!test) {
				www = new WWW (fileURL);
				yield return www;
			} else {
				yield return new WaitForSeconds (0f);
				www = null;
			}


			//If www.error is null, it means No internet connection. Hence, failed events are called
			if (www.error == (null)) {

				if (!test)
					_jsonToBeParsed = www.text;

				_Cross_Promotions = ExtractPromotionalData ();

				Callback (PROMOTION_PROPERTIES.PROMOTIONAL_METADATA_DOWNLOADED);
			} 
			//If www.contains '403', it means platform specific file is not found, hence generic file should be downloaded
			else if (www.error.Contains ("403") && !(fileURL.Equals(ANDROID_SERVER_ADDRESS_GENERIC) || fileURL.Equals(IOS_SERVER_ADDRESS_GENERIC)))  {

				#if UNITY_ANDROID
				Debug.Log ("Starting download from GENERIC SERVER URL: ANDROID");
				StartCoroutine (DownloadFile (ANDROID_SERVER_ADDRESS_GENERIC));
				#endif
				#if UNITY_IPHONE
				Debug.Log ("Starting download from GENERIC SERVER URL: IOS");
				StartCoroutine (DownloadFile (IOS_SERVER_ADDRESS_GENERIC));
				#endif
			} else {

				onCrossPromotionsMetaFailedEvent ();
				onCrossPromotionsDataFailedEvent ();
			}
		}
		

		/* As we are working in Co-Routines, this Callback method receives
		 * all callbacks upon completions and failures
		 */
		public void Callback (PROMOTION_PROPERTIES value)
		{
			if (value == PROMOTION_PROPERTIES.PROMOTIONAL_METADATA_DOWNLOADED) {
				//Promotional Data ready to be downloaded

				foreach (CrossPromotion obj in _Cross_Promotions) {
					if (_Cross_Promotions != null && obj != null)

						StartCoroutine (obj.downloadGraphics ());

				}

				onCrossPromotionRefreshedEvent ();

			} else if (value == PROMOTION_PROPERTIES.PROMOTIONAL_DATA_DOWNLOADED) {
				//Save IFF data for ALL cross promotions have been downloaded

				totalPromotionsDownloaded ++;
				if (totalPromotionsDownloaded == _Cross_Promotions.Length) {
					totalPromotionsDownloaded = 0; //resetting
					StartCoroutine (SaveDataToDisk ());
					onCrossPromotionsLoadedEvent ();
				}

			} else if (value == PROMOTION_PROPERTIES.PROMOTIONAL_METADATA_DOWNLOAD_FAILED) {

				onCrossPromotionsMetaFailedEvent ();

			} else if (value == PROMOTION_PROPERTIES.PROMOTIONAL_DATA_DOWNLOAD_FAILED) {

				onCrossPromotionsDataFailedEvent ();
			}
		}

		/* ExtractPromotionalData() is responsible for parsing data from JSON 
		 * and converting into CrossPromotion class objects. After this method, 
		 * all cross promotion data is accessible through '_Cross_Promotions' data member
		 */
		private CrossPromotion[] ExtractPromotionalData ()
		{
		
			CrossPromotion[] crossPromotions;

			JsonData node = JsonMapper.ToObject (_jsonToBeParsed);

			crossPromotions = new CrossPromotion[node.Count - 1];
				
			float refreshRate = float.Parse (((string)node ["refresh_rate"]));

			_refresh_rate = refreshRate;
				
			/*First element is Refresh Rate and rest of the elements are cross promotions. 
			 *So we have to subtract from the total count to get only cross promotion nodes
			 */
			for (int i=1; i <= node.Count-1; i++) {
					
				crossPromotions [i - 1] = new CrossPromotion ();
					
				crossPromotions [i - 1].Init ((string)node ["promotion" + i.ToString ()] ["title"], 
					                              (string)node ["promotion" + i.ToString ()] ["promo"],
					                              (string)node ["promotion" + i.ToString ()] ["text"],
					                              (string)node ["promotion" + i.ToString ()] ["url"],
					                              (string)node ["promotion" + i.ToString ()] ["refID"], this);
			}

			return crossPromotions;
		}

		public CrossPromotion[] getCrossPromotions ()
		{
			return _Cross_Promotions;
		}
		
		public IEnumerator SaveDataToDisk ()
		{
			yield return new WaitForSeconds (0f);
						
			PreviewLabs.CustomPlayerPrefs.SetFloat ("refresh_rate", _refresh_rate);
			PreviewLabs.CustomPlayerPrefs.SetInt ("number_of_promotions", _Cross_Promotions.Length);
					
			for (int i=0; i<_Cross_Promotions.Length; i++) {
				
				PreviewLabs.CustomPlayerPrefs.SetString ("promotion" + i + "_" + "game_title", _Cross_Promotions [i].GameTitle);
				PreviewLabs.CustomPlayerPrefs.SetString ("promotion" + i + "_" + "promo_image_url", _Cross_Promotions [i].PromoImageURL);
				PreviewLabs.CustomPlayerPrefs.SetString ("promotion" + i + "_" + "text", _Cross_Promotions [i].Text);
				PreviewLabs.CustomPlayerPrefs.SetString ("promotion" + i + "_" + "click_url", _Cross_Promotions [i].ClickURL);
				PreviewLabs.CustomPlayerPrefs.SetString ("promotion" + i + "_" + "ref_id", _Cross_Promotions [i].RefID);
				
				SaveTexture (_Cross_Promotions [i].getPromoImageTexture (), "promotion" + i + "_" + _Cross_Promotions [i].GameTitle);
				
			}

			PreviewLabs.CustomPlayerPrefs.SetString ("saving_time", System.DateTime.Now.ToBinary ().ToString ());

			PreviewLabs.CustomPlayerPrefs.Flush ();

		}

		public IEnumerator LoadDataFromDisk ()
		{
			if (!File.Exists (PreviewLabs.CustomPlayerPrefs.getFileName ())) {
				#if UNITY_ANDROID
					StartCoroutine (DownloadFile (ANDROID_SERVER_ADDRESS));
				#endif
				#if UNITY_IPHONE
					StartCoroutine (DownloadFile (IOS_SERVER_ADDRESS));
				#endif
			} else {
				float refreshRate = PreviewLabs.CustomPlayerPrefs.GetFloat ("refresh_rate");

				int numberOfPromotions = PreviewLabs.CustomPlayerPrefs.GetInt ("number_of_promotions");

				System.DateTime temp = System.DateTime.FromBinary (System.Convert.ToInt64 (PreviewLabs.CustomPlayerPrefs.GetString ("saving_time")));
				System.TimeSpan ts = System.DateTime.Now.Subtract (temp);

				if (ts.TotalSeconds >= refreshRate * 60 * 60) { //Converting it into seconds
					#if UNITY_ANDROID
					StartCoroutine (DownloadFile (ANDROID_SERVER_ADDRESS));
					#endif
					#if UNITY_IPHONE
					StartCoroutine (DownloadFile (IOS_SERVER_ADDRESS));
					#endif
				} else {

					//Check if cross promotions object already contain something, it has already been downloaded and loaded into memory. 
					if (_Cross_Promotions == null) {

						_Cross_Promotions = new CrossPromotion[numberOfPromotions];

						for (int i=0; i<_Cross_Promotions.Length; i++) {
					
							_Cross_Promotions [i] = new CrossPromotion ();

							_Cross_Promotions [i].Init (PreviewLabs.CustomPlayerPrefs.GetString ("promotion" + i + "_" + "game_title"), 
						                          PreviewLabs.CustomPlayerPrefs.GetString ("promotion" + i + "_" + "promo_image_url"),
						                          PreviewLabs.CustomPlayerPrefs.GetString ("promotion" + i + "_" + "text"),
						                          PreviewLabs.CustomPlayerPrefs.GetString ("promotion" + i + "_" + "click_url"),
						                          PreviewLabs.CustomPlayerPrefs.GetString ("promotion" + i + "_" + "ref_id"),
						                          this,
						                          RetriveTexture ("promotion" + i + "_" + PreviewLabs.CustomPlayerPrefs.GetString ("promotion" + i + "_" + "game_title")));

						}

						onCrossPromotionsLoadedEvent ();
						yield return 0;
					} else {
						Debug.Log ("Cross Promotions data already in memory, No parsing from file needed");
					}
				}

			}
		}
		
		void SaveTexture (Texture2D tex, string textureName)
		{
			byte[] byteArray;
			byteArray = tex.EncodeToPNG ();
			
			string textureBytes = Convert.ToBase64String (byteArray);
			
			PreviewLabs.CustomPlayerPrefs.SetString (textureName, textureBytes);
			
			PreviewLabs.CustomPlayerPrefs.SetInt (textureName + "_w", tex.width);
			PreviewLabs.CustomPlayerPrefs.SetInt (textureName + "_h", tex.height);
			PreviewLabs.CustomPlayerPrefs.SetInt (textureName + "_f", (int)tex.format);
		}

		Texture2D RetriveTexture (string savedImageName)
		{
			string temp = PreviewLabs.CustomPlayerPrefs.GetString (savedImageName);
			
			int width = PreviewLabs.CustomPlayerPrefs.GetInt (savedImageName + "_w");
			int height = PreviewLabs.CustomPlayerPrefs.GetInt (savedImageName + "_h");
			TextureFormat format = (TextureFormat)PreviewLabs.CustomPlayerPrefs.GetInt (savedImageName + "_f");

			byte[] byteArray = Convert.FromBase64String (temp);
			
			Texture2D tex = new Texture2D (width, height, format, false);
			tex.LoadImage (byteArray);

			return tex;
				
		}
	}
}
