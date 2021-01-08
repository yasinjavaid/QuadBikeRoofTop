using UnityEngine;
using System.Collections;

public class CamAdjust : MonoBehaviour {

	// Use this for initialization
	public UILabel dist,height;
	static float h,d;
	SmoothFollow smoothFollow;
	bool isDown = false;
	void Start () {
		Invoke ("kuchbhe", 2.0f);
	}
	void kuchbhe()
	{
		smoothFollow = Camera.main.GetComponent<SmoothFollow>();
		h = smoothFollow.h;
		d = smoothFollow.d;
		height.text = "H: "+h.ToString();
		dist.text = "D: "+d.ToString();

	}
	// Update is called once per frame
	void Update () {
		if(isDown){
			smoothFollow.h = h;
			smoothFollow.d = d;

			if(this.gameObject.name == "Hup")
			{
				h+=0.03f;
			}
			else if(this.gameObject.name == "Hdown")
			{
				h-=0.03f;
			}
			else if(this.gameObject.name == "Dup")
			{
				d+=0.03f;
			}
			else if(this.gameObject.name == "Ddown")
			{
				d-=0.03f;
			}
			height.text = "H: "+h.ToString();
			dist.text = "D: "+d.ToString();
		}
	}
	void OnPress(bool down)
	{
		isDown = down;
	}
//	void OnClick()
//	{
//		if(this.gameObject.name == "Hup")
//		{
//			h+=0.03f;
//		}
//		else if(this.gameObject.name == "Hdown")
//		{
//			h-=0.03f;
//		}
//		else if(this.gameObject.name == "Dup")
//		{
//			d+=0.03f;
//		}
//		else if(this.gameObject.name == "Ddown")
//		{
//			d-=0.03f;
//		}
//
//	}
}
