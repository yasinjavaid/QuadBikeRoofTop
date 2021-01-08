using UnityEngine;
using System.Collections;
using System;

public class CameraControlPPnew : MonoBehaviour {

	// Use this for initialization
	public static float height;
	public static float distance;
	private bool upPressed,downPressed,leftPressed,rightPressed;
	public GUIText h,d;
	
	void Start () {
		upPressed=false;
		downPressed=false;
		leftPressed=false;
		rightPressed=false;
		height = 1.5f;
		distance = 5.5f;
		h.text = "H: "+height.ToString();
		d.text =  "D: "+distance.ToString();
	}
	
	// Update is called once per frame
	void Update () {
//		if(upPressed)
//		{
//			height=height+0.3f;
//			UserPrefs.currentHeight = height;
//			SmoothFollow.height = height;
//		}else if(downPressed)
//		{
//			height=height-0.3f;
//			UserPrefs.currentHeight = height;
//			SmoothFollow.height = height;
//		}else if(leftPressed)
//		{
//			distance=distance+0.3f;
//			UserPrefs.currentDistance = distance;
//			SmoothFollow.distance = distance;
//			
//		}else if(rightPressed)
//		{
//			distance=distance-0.3f;
//			UserPrefs.currentDistance = distance;
//			SmoothFollow.distance = distance;
//		}
//		d.text = "D: "+distance.ToString();
//		h.text = "H: "+height.ToString();

	
		
	}
	void OnClick()
	{
		if(this.name.Equals("Up"))
		{
			height=height+0.2f;
			//UserPrefs.currentHeight = height;
			SmoothFollow.height = height;
		}
		else if(this.name.Equals("Down"))
		{
			height=height-0.2f;
			//UserPrefs.currentHeight = height;
			SmoothFollow.height = height;
		}
		else if(this.name.Equals("Left"))
		{
			distance=distance+0.2f;
			//UserPrefs.currentDistance = distance;
			SmoothFollow.distance = distance;
		}
		else if(this.name.Equals("Right"))
		{
			distance=distance-0.2f;
			//UserPrefs.currentDistance = distance;
			SmoothFollow.distance = distance;
		}
		d.text = "D: "+distance.ToString();
		h.text = "H: "+height.ToString();

	}
//	void OnPress (bool isDown)
//	{
//		Debug.Log("************************");
//		if(this.name.Equals("Up"))
//		{
//			if(isDown)
//			{
//				upPressed=true;
//			}else if(!isDown)
//			{
//				upPressed=false;
//			}
//		}
//		else if(this.name.Equals("Down"))
//		{
//			if(isDown)
//			{
//				downPressed=true;
//			}else if(!isDown)
//			{
//				downPressed=false;
//			}
//		}
//		else if(this.name.Equals("Left"))
//		{
//			if(isDown)
//			{
//				leftPressed=true;
//			}else if(!isDown)
//			{
//				leftPressed=false;
//			}
//		}
//		else if(this.name.Equals("Right"))
//		{
//		if(isDown)
//			{
//				rightPressed=true;
//			}else if(!isDown)
//			{
//				rightPressed=false;
//			}
//		}
		
//}
}
