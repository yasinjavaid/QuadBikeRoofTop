using UnityEngine;
using System.Collections;

public class RingsControl : MonoBehaviour {
	
////	public int TotalRings = 0;
//	private int GreenRing=0;
//	public Transform [] RingsArray;
//	public Material GreenRingMaterial;
//	public Material LastRingMaterial;
//	
//	void Awake()
//	{
//		//RingsArray = new Transform[TotalRings];	
//	}
//	
//	// Use this for initialization
//	void Start () {	
//
//		Invoke("rotatingCircle", 0.1f);
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	}
//	
//	void rotatingCircle(){
//		foreach(Transform ring in RingsArray)
//		{
//			if(ring)
//			ring.Rotate( new Vector3(10.0f,0.0f,0.0f));
//		}
//		
//		Invoke("rotatingCircle", 0.1f);
//
//	}
//	
//	
//	public void SetupNextRing()
//	{
//		GreenRing++;
//		if(RingsArray.Length - 1 > GreenRing)
//		{
//			RingsArray[GreenRing].GetComponent<Renderer>().material=GreenRingMaterial;
//			RingsArray[GreenRing].tag="GreenRing";
//		}
//		else if(RingsArray.Length > GreenRing)
//		{
//			RingsArray[GreenRing].GetComponent<Renderer>().material=LastRingMaterial;
//			RingsArray[GreenRing].tag="GreenRing";
//		}
//		else
//		{
//			StartCoroutine(FinishLevel());
//		}
//		
//	}
//	
//	IEnumerator FinishLevel()
//	{
//		yield return new WaitForSeconds(2);
//		
//		WheelControllerGeneric script = (WheelControllerGeneric) GameObject.FindGameObjectWithTag("Player").transform.GetComponent("WheelControllerGeneric");
//		script.LevelCompleted();
//		
//	}
	
}
