using UnityEngine;
using System.Collections;

public class VehicleClass : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public class Vehicle
	{
		public string name;
		public int price;

		public int engineCurrentUpgradeLevel;
		public int handlingCurrentUpgradeLevel;
		public int brakeCurrentUpgradeLevel;

		public int []engineUpgradePrice;
		public int []handlingUpgradePrice;
		public int []brakeUpgradePrice;


		public int []colorUnlockPrice;
		public bool []colorUnlocked;

		public int []wheelUnlockPrice;
		public bool []wheelUnlocked;

		public int currentColor;
		public int currentWheel;


//		public int brakeCurrentUpgradeLevel;
//		public int tiresCurrentUpgradeLevel;
//		public int engineTotalUpgradeLevel;
//		public int steeringTotalUpgradeLevel;
//		public int brakeTotalUpgradeLevel;
//		public int tiresTotalUpgradeLevel;
//		public int carFuel;
//		public int []tiresUpgradePrice;
			
		
		public Vehicle(string name, int price, int engineCurrentUpgradeLevel, int handlingCurrentUpgradeLevel, int brakeCurrentUpgradeLevel,  
		               int []engineUpgradePrice , int []handlingUpgradePrice, int []brakeUpgradePrice, int []colorUnlockPrice, bool []colorUnlocked,
		               int []wheelUnlockPrice, bool []wheelUnlocked, int currentColor, int currentWheel
			
			){
				this.name = name;
//				this.carFuel=fuel;
				this.price = price;
				this.engineCurrentUpgradeLevel = engineCurrentUpgradeLevel;
				this.handlingCurrentUpgradeLevel = handlingCurrentUpgradeLevel;
				this.brakeCurrentUpgradeLevel = brakeCurrentUpgradeLevel;
//				this.tiresCurrentUpgradeLevel = tiresCurrentUpgradeLevel;
//				this.engineTotalUpgradeLevel = engineTotalUpgradeLevel;
//				this.steeringTotalUpgradeLevel = steeringTotalUpgradeLevel;
//				this.brakeTotalUpgradeLevel = brakeTotalUpgradeLevel;
//				this.tiresTotalUpgradeLevel = tiresTotalUpgradeLevel;
				this.engineUpgradePrice = new int[engineUpgradePrice.Length];
				this.handlingUpgradePrice = new int[handlingUpgradePrice.Length];
				this.brakeUpgradePrice = new int[brakeUpgradePrice.Length];
//				this.tiresUpgradePrice = new int[tiresUpgradePrice.Length];

				for(int i = 0; i<engineUpgradePrice.Length; i++){
					this.engineUpgradePrice[i] = engineUpgradePrice[i];
					this.handlingUpgradePrice[i] = handlingUpgradePrice[i];
					this.brakeUpgradePrice[i] = brakeUpgradePrice[i];
					//	this.tiresUpgradePrice[i] = tiresUpgradePrice[i];
					
				}

			this.wheelUnlockPrice = new int[wheelUnlockPrice.Length];
			this.wheelUnlocked = new bool[wheelUnlocked.Length];


			for(int i = 0; i < wheelUnlockPrice.Length; i++)
			{
				this.wheelUnlockPrice[i] = wheelUnlockPrice[i];
				this.wheelUnlocked[i] = wheelUnlocked[i];
			}

			this.colorUnlockPrice = new int[colorUnlockPrice.Length];
			this.colorUnlocked = new bool[colorUnlocked.Length];

			for(int i = 0; i < colorUnlockPrice.Length; i++)
			{
				this.colorUnlockPrice[i] = colorUnlockPrice[i];
				this.colorUnlocked[i] = colorUnlocked[i];
			}

			this.currentColor = currentColor;
			this.currentWheel = currentWheel;
				
			
		}
		
		
		
		
	}
	




}
