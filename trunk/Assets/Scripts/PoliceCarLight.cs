using UnityEngine;
using System.Collections;

public class PoliceCarLight : MonoBehaviour {

	public Material Car1RoofLightMaterial;
	public Material Car2RoofLightMaterial;
	public Material Car3RoofLightMaterial;

	private Material CurrentCarMaterial;

	public Texture Car1Light1;
	public Texture Car2Light1;
	public Texture Car3Light1;

	private Texture CurrentCarLight1;

	public Texture Car1Light2;
	public Texture Car2Light2;
	public Texture Car3Light2;

	public Light light1;
	public Light light2;

	private Texture CurrentCarLight2;

	// Use this for initialization
	void Start () {

		light1.gameObject.SetActive(true);
		light2.gameObject.SetActive(false);

		if(this.gameObject.name == "PoliceCar1(Clone)")
		{
			CurrentCarMaterial=Car1RoofLightMaterial;
			CurrentCarLight1=Car1Light1;
			CurrentCarLight2=Car1Light2;
		
		}
		else if(this.gameObject.name == "PoliceCar2(Clone)")
		{
			CurrentCarMaterial=Car2RoofLightMaterial;
			CurrentCarLight1=Car2Light1;
			CurrentCarLight2=Car2Light2;

		}
		else if(this.gameObject.name == "MonsterTruck(Clone)")
		{
			CurrentCarMaterial=Car3RoofLightMaterial;
			CurrentCarLight1=Car3Light1;
			CurrentCarLight2=Car3Light2;

		}
		StartCoroutine(Light1());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Light1()
	{
		yield return new WaitForSeconds(1);

//		CurrentCarMaterial.mainTexture=CurrentCarLight1;
		light1.gameObject.SetActive(true);
		light2.gameObject.SetActive(false);
		StartCoroutine(Light2());

	}

	IEnumerator Light2()
	{
		yield return new WaitForSeconds(1);		

//		CurrentCarMaterial.mainTexture=CurrentCarLight2;
		light2.gameObject.SetActive(true);
		light1.gameObject.SetActive(false);
		StartCoroutine(Light1());

	}



}
