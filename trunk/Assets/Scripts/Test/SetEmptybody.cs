using UnityEngine;
using System.Collections;

public class SetEmptybody : MonoBehaviour {

	// Use this for initialization
	static float Y,Z;
	Transform emptyBody;
	public GUIText yT,zT;
	void Start () {
		Invoke ("SetBody", 1f);
	}
	void SetBody()
	{
		emptyBody = GameObject.Find ("EmptyBody").transform;
		Y = emptyBody.localPosition.y;
		Z = emptyBody.localPosition.z;
		yT.text = "Y = "+Y.ToString ();
		zT.text = "Z = "+Z.ToString ();

	}
	// Update is called once per frame
	void Update () {

	}
	void OnClick()
	{
		if(this.name.Equals("Up"))
		{
			Y = Y+0.001f;
		}
		else if(this.name.Equals("Down"))
		{
			Y = Y-0.001f;

	}
		else if(this.name.Equals("Left"))
		{
			Z = Z+0.001f;
		
		}
		else if(this.name.Equals("Right"))
		{
			Z = Z-0.001f;
		}
		yT.text = "Y = "+Y.ToString ();
		zT.text = "Z = "+Z.ToString ();
		emptyBody.localPosition = new Vector3 (emptyBody.localPosition.x, Y, Z);
		
	}

}
