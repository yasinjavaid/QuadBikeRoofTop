using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {
	
	// Use this for initialization
	bool fadeOutNow = false;
	 float fadeSpeed = 0.01f;
	public Color startingColor;
	Color color = new Color();
	Material mat;
	Color tempColor;
	void Start () {
		//color = GetComponent<GUITexture>().color;
		mat = GetComponent<Renderer>().material;
		color = mat.GetColor("_TintColor");
		tempColor = mat.GetColor("_TintColor");
		
	}
	void OnEnable()
	{
		mat = GetComponent<Renderer>().material;
		//GetComponent<GUITexture>().color = startingColor;
		mat.SetColor("_TintColor", startingColor);
		//tempColor = GetComponent<GUITexture>().color;
		tempColor =mat.GetColor("_TintColor");
		fadeOutNow = true;
	}
	// Update is called once per frame
	void Update () {
		if(fadeOutNow)
		{
			
			tempColor.a -=fadeSpeed;
			//GetComponent<GUITexture>().color =tempColor;
			mat.SetColor("_TintColor", tempColor);
			if(tempColor.a < 0)
			{fadeOutNow = true;
				this.gameObject.SetActive(false);
			}
			
		}
	}
}
