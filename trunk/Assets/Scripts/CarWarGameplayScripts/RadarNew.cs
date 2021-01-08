using UnityEngine;
using System.Collections;

public class RadarNew : MonoBehaviour 
{
	
	// radar! by oPless from the original javascript by PsychicParrot, 
	// who in turn adapted it from a Blitz3d script found in the
	// public domain online somewhere ....
	//
	/*Textures for radar blips*/
	public Texture blipPlayer;
	public Texture blipFOV;

	public Texture blipEnemy;
	public Texture radarBG;

	/**************************/
	[HideInInspector]
	public Transform centerObject;					// player will center reference for radar
	Transform player;
	public float radarZoom;					// zoom level of the radar, decrease value to zoom out and increase value to zoom in
	//public Vector2 mapCenter = new Vector2(50,50);	// not being used
	private string removeString;
	private string killedPrey;
	private int index;
	private float timeStamp;
	private float drawInterval;

	/*****************Animal tags*****************/
	private string tagFilter1 = "eat";
	/*********************************************/

	public float radarXAdjustRatio;					// the ratio by which radar will be drawn on screen on the LEFT, decrease to draw towards LEFT
	public float radarYAdjustRatio;					// the ratio by which radar will be drawn on screen on the TOP, increase to draw towards TOP
	private float radarX;								// radar X axis position
	private float radarY;								// radar Y axis position
	private float radarUpdatedX;
	private float radarUpdatedY;

	/**Original radar BG texture dimension**/
	private int originalBGLength;						// to compare original dimensions with the updated dimensions for blip scaling adjustments
	private int originalBGHeight;
	/***************************************/

	/******Radar adjustment parameters******/
	private float radarBGSize;
	private float radarBlipPos;
	private float radarBlipSize;
	private float radarUpdatedBlipSize;
	private float playerBlipPos;
	private float playerBlipSize; 
	private float playerUpdatedBlipSize;
	private float playerFOVBlipPosX;
	private float playerFOVBlipPosY;
	private float playerFOVBlipSize;
	public float radarMaxDistance;						// maximum distance radar can cover with in particluar zoom level
	/***************************************/

	void Start()
	{
		Invoke("findPlayer",1f);
		removeString = @"(Clone)";

		//radarZoom = 3f;	
		//radarXAdjustRatio = 0.95f;
		//radarYAdjustRatio = 5.6f;
		radarBGSize = 3f;
		radarBlipSize = 35f;
		playerBlipSize = 10f;
		//radarMaxDistance = 23f;

		originalBGLength = 180;
		originalBGHeight = 183;

		playerBlipPos = 2.3f;
		radarBlipPos = 2.2f;
		playerFOVBlipPosX = 3f;
		playerFOVBlipPosY = 35f;
		playerFOVBlipSize = 20f;

		radarX = Screen.width - (Screen.width / radarXAdjustRatio);				
		radarY = Screen.height / radarYAdjustRatio;
		
		radarUpdatedX = Screen.width / radarBGSize;
		radarUpdatedY = Screen.height / radarBGSize;
		radarUpdatedBlipSize =  Screen.width / radarBlipSize;
		playerUpdatedBlipSize = Screen.width / (radarBlipSize - playerBlipSize);

		timeStamp = Time.time;
		drawInterval = 0.0f;
	}
	void findPlayer()
	{
		centerObject = GameObject.Find("Center").transform;
		player = GameObject.FindGameObjectWithTag("Player2").transform;

	}
	void OnGUI() 
	{
		if(centerObject==null)
			return;
		GUI.DrawTexture(new Rect(radarX, radarY, Screen.width / radarBGSize, Screen.height / radarBGSize), radarBG, ScaleMode.ScaleToFit);
			
		//drawBlip(centerObject.gameObject, blipPlayer);
		//drawBlip(centerObject.gameObject, blipFOV);
		DrawBlipsForType1(tagFilter1);

	}
	private void DrawBlipForBurrows (string tagName1, string tagName2)
	{
		GameObject[] gos1 = GameObject.FindGameObjectsWithTag(tagName1); 
		GameObject[] gos2 = GameObject.FindGameObjectsWithTag(tagName2); 
		/*
		foreach (GameObject go in gos1)
		{
			drawBlip(go, blipBurrows);
		}

		foreach (GameObject go in gos2)
		{
			if (go.name.Contains("BeeHive"))
			{
				drawBlip(go, blipHoneyComb);
			}
		}
		*/
	}

	private void DrawBlipsForType1 (string tagName)
	{
		// Find all game objects with tag 
		EnemyCar [] enemies = GameObject.FindObjectsOfType<EnemyCar>(); 
		// Iterate through them
		foreach (EnemyCar go in enemies)  
		{
			drawBlip(go.gameObject,blipEnemy);
		}
		drawBlip(player.gameObject,blipPlayer);
	}
	
	private void drawBlip (GameObject go,Texture aTexture)
	{
		Vector3 centerPos = centerObject.position;
		Vector3 extPos = go.transform.position;
		
		// first we need to get the distance of the enemy from the player
		float dist = Vector3.Distance(centerPos, extPos);
		
		float dx = centerPos.x - extPos.x; // how far to the side of the player is the enemy?
		float dz = centerPos.z - extPos.z; // how far in front or behind the player is the enemy?
		
		// what's the angle to turn to face the enemy - compensating for the player's turning?
		float deltay = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg - 270 - centerObject.eulerAngles.y;
		
		// just basic trigonometry to find the point x,y (enemy's location) given the angle deltay
		float bX = dist * Mathf.Cos(deltay * Mathf.Deg2Rad);
		float bY = dist * Mathf.Sin(deltay * Mathf.Deg2Rad);

		bX = bX * radarZoom * (radarUpdatedY / originalBGHeight); // scales down the x-coordinate by half so that the plot stays within our radar
		bY = bY * radarZoom * (radarUpdatedY / originalBGHeight); // scales down the y-coordinate by half so that the plot stays within our radar

		if (dist <= radarMaxDistance)
		{ 
			// this is the diameter of our largest radar circle
			GUI.DrawTexture(new Rect(radarX + (radarUpdatedX/playerBlipPos) + bX, radarY +(radarUpdatedY/playerBlipPos) + bY, playerUpdatedBlipSize, playerUpdatedBlipSize),aTexture);
		
//			if (aTexture.name.Contains("Player"))
//			{
//				GUI.DrawTexture(new Rect(radarX + (radarUpdatedX/playerBlipPos) + bX, radarY +(radarUpdatedY/playerBlipPos) + bY, playerUpdatedBlipSize, playerUpdatedBlipSize),aTexture);
//			}
//
//			if (!aTexture.name.Contains("Player"))
//			{
//				GUI.DrawTexture(new Rect(radarX + (radarUpdatedX/radarBlipPos) + bX, radarY + (radarUpdatedY/radarBlipPos) + bY, radarUpdatedBlipSize, radarUpdatedBlipSize),aTexture);
//			}
//
//			if (aTexture.name.Contains("arrow"))
//			{
//				GUI.DrawTexture(new Rect(radarX + (radarUpdatedX/playerFOVBlipPosX) + bX, radarY +(radarUpdatedY/playerFOVBlipPosY) + bY, Screen.width / (playerFOVBlipSize - playerBlipSize), Screen.width / (playerFOVBlipSize - playerBlipSize)),aTexture);
//			}
		}
		
	}

	public void pause()
	{
		radarX = -1220;
		radarY = -1220;
	}
	
	public void resume()
	{
		radarX = Screen.width - (Screen.width / radarXAdjustRatio);				
		radarY = Screen.height / radarYAdjustRatio;
	}

	
	
}