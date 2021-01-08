using UnityEngine;
using System.Collections;

public class VehicleManager : MonoBehaviour {

	public static VehicleClass.Vehicle []vehicleArray;
	public Texture []Truck1;
	public Texture []Truck2;
	public Texture []Truck3;
	public Color[] vehicleBodyColors = new Color[7];
	//public Texture []Truck4;
	//public Texture []Truck5;
	public Texture []Wheels;

	public int ColorId=1;
	public int wheelId=1;


	void Start(){
		vehicleBodyColors = new Color[7];
		DontDestroyOnLoad(this);
		vehicleBodyColors[0] = Color.red;
		vehicleBodyColors[1] = Color.blue;
		vehicleBodyColors[2] = Color.black;
		vehicleBodyColors[3] = Color.green;
		vehicleBodyColors[4] = Color.yellow;
		vehicleBodyColors[5] = Color.grey;
		vehicleBodyColors[6] = new Color32(0,255,255,255);
	}
	// Use this for initialization
	void Awake () {
		vehicleArray = new VehicleClass.Vehicle[6];
	
		//ZI - Sequence of variables in constructor - For Reference
		/*
		 * 	
		 * name;
		   price;

		 engineCurrentUpgradeLevel;
		 handlingCurrentUpgradeLevel;
		 healthCurrentUpgradeLevel;

		 []engineUpgradePrice;
		 []handlingUpgradePrice;
		 []healthUpgradePrice;

		 []colorUnlockPrice;
		 []colorUnlocked;

		[]wheelUnlockPrice;
		[]wheelUnlocked;
		 */

		 vehicleArray[0] = new VehicleClass.Vehicle(
			"Truck1",
			0,
			1,
			1,
			1,
			new int[3]{500,700,1000},
			new int[3]{500,700,1000},
			new int[3]{500,700,1000}, 
			new int[7]{0,500,500,500,500,500,500},//Color unlock price
			new bool[7]{true, false, false, false, false, false, false},//Color unlock array
			new int[9]{500,500,500,500,500,500,500,500,0},//wheel unlock price
			new bool[9]{false, false, false, false, false, false, false, false, true},//wheel unlock array
			1,9
		);
		
		vehicleArray[1] = new VehicleClass.Vehicle(
			"Truck2",
			5000,
			1,
			1,
			1,
			new int[3]{500,700,1000},
			new int[3]{500,700,1000},
			new int[3]{500,700,1000}, 
			new int[7]{0,500,500,500,500,500,500},//Color unlock price
			new bool[7]{true, false, false, false, false, false, false},//Color unlock array
			new int[9]{0,0,500,500,500,500,500,500,500},//wheel unlock price
			new bool[9]{true, true, false, false, false, false, false, false, false},//wheel unlock array
			1,1
		);

		vehicleArray[2] = new VehicleClass.Vehicle(
			"Truck3",
			20000,
			1,
			1,
			1,
			new int[3]{500,700,1000},
			new int[3]{500,700,1000},
			new int[3]{500,700,1000}, 
			new int[7]{0,500,500,500,500,500,500},//Color unlock price
			new bool[7]{true, false, false, false, false, false, false},//Color unlock array
			new int[9]{0,0,500,500,500,500,500,500,500},//wheel unlock price
			new bool[9]{true, true, false, false, false, false, false, false, false},//wheel unlock array
			1,1
		);

		vehicleArray[3] = new VehicleClass.Vehicle(
			"Truck4",
			30000,
			1,
			1,
			1,
			new int[3]{500,700,1000},
			new int[3]{500,700,1000},
			new int[3]{500,700,1000}, 
			new int[7]{0,500,500,500,500,500,500},//Color unlock price
			new bool[7]{true, false, false, false, false, false, false},//Color unlock array
			new int[9]{0,0,500,500,500,500,500,500,500},//wheel unlock price
			new bool[9]{true, true, false, false, false, false, false, false, false},//wheel unlock array
			1,1
		);

		vehicleArray[4] = new VehicleClass.Vehicle(
			"Truck5",
			40000,
			1,
			1,
			1,
			new int[3]{500,700,1000},
			new int[3]{500,700,1000},
			new int[3]{500,700,1000}, 
			new int[7]{0,500,500,500,500,500,500},//Color unlock price
			new bool[7]{true, false, false, false, false, false, false},//Color unlock array
			new int[9]{0,0,500,500,500,500,500,500,500},//wheel unlock price
			new bool[9]{true, true, false, false, false, false, false, false, false},//wheel unlock array
			1,1
		);
		vehicleArray[5] = new VehicleClass.Vehicle(
			"Truck6",
			2700,
			1,
			1,
			1,
			new int[3]{500,700,1000},
			new int[3]{500,700,1000},
			new int[3]{500,700,1000}, 
			new int[7]{0,500,500,500,500,500,500},//Color unlock price
			new bool[7]{true, false, false, false, false, false, false},//Color unlock array
			new int[9]{0,0,500,500,500,500,500,500,500},//wheel unlock price
			new bool[9]{true, true, false, false, false, false, false, false, false},//wheel unlock array
			1,1
		);

		SaveandLoad.Load();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
