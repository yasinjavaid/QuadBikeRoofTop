using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
		//iTween.MoveAdd(gameObject,new Hashtable(){{iT.MoveAdd.x,-5},{iT.MoveAdd.y,5},{iT.MoveAdd.easetype,}});
	}
}

