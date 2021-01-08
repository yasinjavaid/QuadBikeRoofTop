using UnityEngine;
using System.Collections;

public class SaveandLoad : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public static void Save ( )
	{	
		Debug.Log("Saving at index "+(UserPrefs.currentVehicle-1));
		Debug.Log(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel);
		
		for(int i = 0; i < VehicleManager.vehicleArray.Length; i++)
		{
			PreviewLabs.PlayerPrefs.SetInt	( "vehicleArrayEngineCurrentUpgradeLevel"+(i),VehicleManager.vehicleArray[i].engineCurrentUpgradeLevel);
			
		}
		
		PreviewLabs.PlayerPrefs.SetInt	( "vehicleArrayEngineCurrentUpgradeLevel"+(UserPrefs.currentVehicle-1),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel);
		PreviewLabs.PlayerPrefs.SetInt	( "vehicleArrayHandlingCurrentUpgradeLevel"+(UserPrefs.currentVehicle-1),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel);
		PreviewLabs.PlayerPrefs.SetInt	( "vehicleArrayBrakeCurrentUpgradeLevel"+(UserPrefs.currentVehicle-1),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel);
		
		PreviewLabs.PlayerPrefs.SetInt	( "vehicleCurrentColor"+(UserPrefs.currentVehicle-1),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentColor);
		for(int j=0;j< VehicleManager.vehicleArray.Length;j++){
			PreviewLabs.PlayerPrefs.SetInt	( "vehicleCurrentWheel"+(j),VehicleManager.vehicleArray[j].currentWheel);
		}
		
		
		
		//Saving unlocked color array against selected car
		for(int i = 0; i < VehicleManager.vehicleArray[0].colorUnlocked.Length; i++)
		{
			PreviewLabs.PlayerPrefs.SetBool( "vehicleArrayColorUnlock" + (UserPrefs.currentVehicle-1) + "Color" + i.ToString(),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].colorUnlocked[i]);
		}
		
		//Saving unlocked wheel array against selected car
		for(int j=0;j< VehicleManager.vehicleArray.Length;j++){
			for(int i = 0; i < VehicleManager.vehicleArray[j].wheelUnlocked.Length; i++)
			{
				PreviewLabs.PlayerPrefs.SetBool( "vehicleArrayWheelUnlock" + (j) + "Wheel" + i.ToString(),VehicleManager.vehicleArray[j].wheelUnlocked[i]);
			}
		}
		
		PreviewLabs.PlayerPrefs.SetInt("totalCoins",UserPrefs.totalCoins);
		PreviewLabs.PlayerPrefs.Flush ( ) ;
		Debug.Log("ASfter"+VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel);	
	}
	
	
	public static void Load ( )
	{
//		Debug.Log("loading from index "+(UserPrefs.currentVehicle-1));
		
		
		//			VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel = PreviewLabs.PlayerPrefs.GetInt	( "vehicleArraybrakeCurrentUpgradeLevel"+(UserPrefs.currentVehicle-1),VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel);
		for(int i = 0; i < VehicleManager.vehicleArray.Length; i++)
		{
			VehicleManager.vehicleArray[i].engineCurrentUpgradeLevel = PreviewLabs.PlayerPrefs.GetInt	( "vehicleArrayEngineCurrentUpgradeLevel"+i,VehicleManager.vehicleArray[i].engineCurrentUpgradeLevel);
			VehicleManager.vehicleArray[i].handlingCurrentUpgradeLevel = PreviewLabs.PlayerPrefs.GetInt	( "vehicleArrayHandlingCurrentUpgradeLevel"+i,VehicleManager.vehicleArray[i].handlingCurrentUpgradeLevel );
			VehicleManager.vehicleArray[i].brakeCurrentUpgradeLevel = PreviewLabs.PlayerPrefs.GetInt	( "vehicleArrayBrakeCurrentUpgradeLevel"+i,VehicleManager.vehicleArray[i].brakeCurrentUpgradeLevel );
			VehicleManager.vehicleArray[i].currentColor = PreviewLabs.PlayerPrefs.GetInt("vehicleCurrentColor"+i,VehicleManager.vehicleArray[i].currentColor );
			VehicleManager.vehicleArray[i].currentWheel= PreviewLabs.PlayerPrefs.GetInt("vehicleCurrentWheel"+i,VehicleManager.vehicleArray[i].currentWheel );
			
		}
		
		
		for (int j=0; j< VehicleManager.vehicleArray.Length; j++) {
			
			//Loading unlocked color array against selected car
			for (int i = 0; i < VehicleManager.vehicleArray[0].colorUnlocked.Length; i++) {
				VehicleManager.vehicleArray [j].colorUnlocked [i] = PreviewLabs.PlayerPrefs.GetBool ("vehicleArrayColorUnlock" + j + "Color" + i.ToString (), VehicleManager.vehicleArray [j].colorUnlocked [i]);
			}
		}
		
		for (int j=0; j< VehicleManager.vehicleArray.Length; j++) {
			
			//Loading unlocked wheel array against selected car
			for (int i = 0; i < VehicleManager.vehicleArray[0].wheelUnlocked.Length; i++) {
				VehicleManager.vehicleArray [j].wheelUnlocked [i] = PreviewLabs.PlayerPrefs.GetBool ("vehicleArrayWheelUnlock" + j + "Wheel" + i.ToString (), VehicleManager.vehicleArray [j].wheelUnlocked [i]);
			}
			
		}
		
		UserPrefs.totalCoins = PreviewLabs.PlayerPrefs.GetInt("totalCoins",UserPrefs.totalCoins);
		
	}
}
