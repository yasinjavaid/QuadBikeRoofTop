using UnityEngine;
using System.Collections;
using CustomCrossPromotions;

namespace CustomCrossPromotions
{
	public class testCrossPromotion : MonoBehaviour
	{


		public Material prom1;
		public Material prom2;
		public Material prom3;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void RetrieveTextures ()
		{
			//Write logic to display downloaded graphics in materials

			CrossPromotion[] promotions = CrossPromotionManager.instance.getCrossPromotions ();
			prom1.mainTexture = promotions [0].getPromoImageTexture ();
			Debug.Log (promotions [0].PromoImageURL);

//			prom2.mainTexture = promotions [1].getPromoImageTexture ();
//			Debug.Log (promotions [1].PromoImageURL);

//			prom3.mainTexture = promotions [2].getPromoImageTexture ();
//			Debug.Log (promotions [2].PromoImageURL);



		}
	}
}
