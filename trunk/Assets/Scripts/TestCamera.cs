using UnityEngine;
using System.Collections;

public class TestCamera : MonoBehaviour {

	// Use this for initialization
	public UILabel camh,camd;
	public static int b,s,str;
	public static float h,d;
	void Start () {
	
//		h = SmoothFollow.height;
//		d = SmoothFollow.distance;

		h = 3.2f;
		d = 9.4f;

		camh.text = h.ToString ();
		camd.text = d.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		if (this.gameObject.name == "su") 
		{
			s++;
		}
		else if (this.gameObject.name == "sd")
		{
			s--;
		}
		else if(this.gameObject.name == "bu")
		{
			b++;
		}
		else if(this.gameObject.name == "bd")
		{ 
			b--;
		}
		else if(this.gameObject.name == "stu")
		{
			str++;
		}
		else if(this.gameObject.name == "std")
		{
			str--;
		}
		else if(this.gameObject.name == "hu")
		{
			h+=0.3f;
		}
		else if(this.gameObject.name == "hd")
		{
			h-=0.3f;
		}
		else if(this.gameObject.name == "du")
		{
			d+=0.3f;
		}
		else if(this.gameObject.name == "dd")
		{
			d-=0.3f;
		}
		camd.text = d.ToString ();
		camh.text = h.ToString ();
	
	}
}
