/* 	Author: Zaki Imtiaz
 * 	Date: August 2015
 * 
 *  Intro: Cross Promotion serves as the Data Structure for individual Cross Promotion. 
 *  It has been composed in CrossPromotionManager and is accessible through it as well.
 */

using UnityEngine;
using System.Collections;
using CustomCrossPromotions;

namespace CustomCrossPromotions
{
	public class CrossPromotion
	{


		string gameTitle;

		public string GameTitle {
			get {
				return gameTitle;
			}
		}

		string promoImageURL;

		public string PromoImageURL {
			get {
				return promoImageURL;
			}
		}

		string text;

		public string Text {
			get {
				return text;
			}
		}

		string clickURL;

		public string ClickURL {
			get {
				return clickURL;
			}
		}

		string refID;

		public string RefID {
			get {
				return refID;
			}
		}

		CrossPromotionManager Manager;

		Texture2D PromoImageTexture;

		public Texture2D getPromoImageTexture()
		{
			return PromoImageTexture;
		}

		public CrossPromotion ()
		{
			this.gameTitle = "";
			this.promoImageURL = "";
			this.text = "";
			this.clickURL = "";
			this.refID = "";

		}

		public CrossPromotion (string gameTitle, string promoImageURL, string text, string clickURL, string refID)
		{

			this.gameTitle = gameTitle;
			this.promoImageURL = promoImageURL;
			this.text = text;
			this.clickURL = clickURL;
			this.refID = refID;

		}

		public void Init (string gameTitle, string promoImageURL, string text, string clickURL, string refID, CrossPromotionManager manager, Texture2D tex = null)
		{
		
			this.gameTitle = gameTitle;
			this.promoImageURL = promoImageURL;
			this.text = text;
			this.clickURL = clickURL;
			this.refID = refID;
			this.Manager = manager;

			PromoImageTexture = tex;

		}


		public void print ()
		{
			Debug.Log ("title: " + gameTitle 
				+ "** Image URL: " + promoImageURL 
				+ "** Text: " + text 
				+ "** Click URL: " + clickURL
				+ "** Ref ID: " + refID);
		}

		public IEnumerator downloadGraphics ()
		{
			//TODO - In case internet connection failure, fire failed DATA download event. Uncomment following line
//			Manager.Callback (CrossPromotionManager.PROMOTION_PROPERTIES.PROMOTIONAL_DATA_DOWNLOAD_FAILED);

			if (!Manager.test) {
				WWW www;

				www = new WWW (promoImageURL);
				yield return www;
				PromoImageTexture = www.texture;

			}

			Manager.Callback (CrossPromotionManager.PROMOTION_PROPERTIES.PROMOTIONAL_DATA_DOWNLOADED);

		}


	}
}
