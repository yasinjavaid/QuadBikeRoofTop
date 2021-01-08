/* 	Author: Zaki Imtiaz
 * 	Date: August 2015
 * 
 *  Intro: Cross Promotion Android Event listener serves as the event listener for android platform.
 *  This receives events for the following 4 functions:
 *  - onCrossPromotionsLoadedEvent: Called when all cross promotions are loaded and ready to be used
 *  - onCrossPromotionRefreshedEvent: Called when all cross promotions are downloaded for the the first time or after refresh time has been pased
 *  - onCrossPromotionsMetaFailedEvent: Called when meta file has failed download.
 *  - onCrossPromotionsDataFailedEvent: Called when promo graphics have failed to download. 
 * 
 *  Modifications in this class are recommended in order to drive events from Cross Promotion Framework 
 *  to other places in the game framework
 */

using UnityEngine;
using System.Collections;
using CustomCrossPromotions;
using System.Collections.Generic;

namespace CustomCrossPromotions
{
	public class CrossPromotionAndroidEventListener : MonoBehaviour {


		void Awake()
		{
			DontDestroyOnLoad(this);
		}

		public static List<GameObject> registeredObjects;

				
		public static void registerObject(GameObject obj)
		{
			if (registeredObjects == null) {
				registeredObjects = new List<GameObject>();
			}

			registeredObjects.Add (obj);
		}


		void OnEnable()
		{
			// Listen to all events
			CrossPromotionManager.onCrossPromotionsLoadedEvent += onCrossPromotionsLoadedEvent;
			CrossPromotionManager.onCrossPromotionRefreshedEvent += onCrossPromotionRefreshedEvent;
			CrossPromotionManager.onCrossPromotionsMetaFailedEvent += onCrossPromotionsMetaFailedEvent;
			CrossPromotionManager.onCrossPromotionsDataFailedEvent += onCrossPromotionsDataFailedEvent;


		}

		
		void OnDisable()
		{
			// Remove all event handlers
			CrossPromotionManager.onCrossPromotionsLoadedEvent -= onCrossPromotionsLoadedEvent;
			CrossPromotionManager.onCrossPromotionRefreshedEvent -= onCrossPromotionRefreshedEvent;
			CrossPromotionManager.onCrossPromotionsMetaFailedEvent -= onCrossPromotionsMetaFailedEvent;
			CrossPromotionManager.onCrossPromotionsDataFailedEvent -= onCrossPromotionsDataFailedEvent;

		}
		
		
		
		void onCrossPromotionsLoadedEvent()
		{
			Debug.Log( "onCrossPromotionsLoadedEvent" );

			//TODO - For demo scene to work, please uncomment this line. 
			GameObject.FindGameObjectWithTag ("MainMenu").GetComponent<testCrossPromotion> ().RetrieveTextures ();

		}

		void onCrossPromotionRefreshedEvent()
		{
			Debug.Log( "onCrossPromotionRefreshedEvent" );
		}

		void onCrossPromotionsMetaFailedEvent()
		{
			Debug.Log ("onCrossPromotionsMetaFailedEvent");
		}

		void onCrossPromotionsDataFailedEvent()
		{
			Debug.Log ("onCrossPromotionsDataFailedEvent");
		}


	}
}
