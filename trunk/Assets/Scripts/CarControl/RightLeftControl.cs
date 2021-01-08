using UnityEngine;
using System.Collections;

public class RightLeftControl : MonoBehaviour {

//	Vector2 leftTurnScreenPoint;
//	Vector2 rightTurnScreenPoint;
//	Transform leftTurnScreenTransform;
//	Transform rightTurnScreenTransform;
//	
//	public Texture leftTurnScreenPointPress;
//	public Texture leftTurnScreenPointRelease;
//	public Texture rightTurnScreenPointPress;
//	public Texture rightTurnScreenPointRelease;
//	
//	int leftMove ;
//	int rightMove ;
//	bool  isMobile ; 
//	public static int move ;
//	private bool isLeftArrowPressed;
//	private bool isRightArrowPressed;
//
//	void  Start (){
//		isMobile = true;
//		#if UNITY_EDITOR
//			isMobile = false;
//		#endif
//		move = 0;
//		
//		leftMove = -1;
//		rightMove = -1;
//		isLeftArrowPressed = false;
//		isRightArrowPressed = false;
//		leftTurnScreenTransform = GameObject.FindGameObjectWithTag("LeftTurnSteering").transform;
//		rightTurnScreenTransform = GameObject.FindGameObjectWithTag("RightTurnSteering").transform;	
//		
//		leftTurnScreenPoint   = Camera.main.WorldToScreenPoint(leftTurnScreenTransform.position);
//		rightTurnScreenPoint   = Camera.main.WorldToScreenPoint(rightTurnScreenTransform.position);	
//	
//	}
//
//	void  Update (){
//		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY){
//			if(isMobile){
//				ForMobile();
//			}
//			else{
//				ForComputer();
//			}
//		}
//	}
//	
//	
//	void ForComputer(){
//	//	if(Input.GetMouseButtonDown(0))
//	//	{
//			if((leftTurnScreenPoint.x < (Input.mousePosition.x + 100) && leftTurnScreenPoint.x > (Input.mousePosition.x - 60)) && 
//			(leftTurnScreenPoint.y < (Input.mousePosition.y + 130) && leftTurnScreenPoint.y > (Input.mousePosition.y - 130)))
//			{
//				leftTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = leftTurnScreenPointPress;
//				move = -1;  
//			} 
//			else if((rightTurnScreenPoint.x < (Input.mousePosition.x + 80) && rightTurnScreenPoint.x > (Input.mousePosition.x - 100)) && 
//			(rightTurnScreenPoint.y < (Input.mousePosition.y + 130) && rightTurnScreenPoint.y > (Input.mousePosition.y - 130)))
//			{
//				rightTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = rightTurnScreenPointPress;
//				move = 1;
//			}
//			else
//			{
//				move = 0;
//				leftTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = leftTurnScreenPointRelease;      
//				rightTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = rightTurnScreenPointRelease;
//			}
//	//	}
//		
////			if(Input.GetMouseButtonUp(0))
////			{
////				move = 0;
////				leftTurnScreenTransform.renderer.material.mainTexture = leftTurnScreenPointRelease;      
////				rightTurnScreenTransform.renderer.material.mainTexture = rightTurnScreenPointRelease;
////			}
//	}
//	
//	void ForMobile(){
//		for ( int i= 0 ; i < Input.touchCount ; i++ ) 
//		{
//		
//			if((leftTurnScreenPoint.x < (Input.GetTouch(i).position.x + 200) && leftTurnScreenPoint.x > (Input.GetTouch(i).position.x - 120)) && 
//			(leftTurnScreenPoint.y < (Input.GetTouch(i).position.y + 130) && leftTurnScreenPoint.y > (Input.GetTouch(i).position.y - 130)))
//			{
//				CameraRotation.isBtnClicked = true;
//				if(Input.GetTouch(i).phase == TouchPhase.Began)
//				{
//					move = -1;
//						leftTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = leftTurnScreenPointPress; 
//						rightTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = rightTurnScreenPointRelease;
//				}
//				if(Input.GetTouch(i).phase == TouchPhase.Moved)
//				{
//					move = -1;
//					if(!isLeftArrowPressed)
//					{
//						isLeftArrowPressed = true;
//						leftTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = leftTurnScreenPointPress; 
//						rightTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = rightTurnScreenPointRelease;
//					}
//				
//				}
//				
//		
//				if(Input.GetTouch(i).phase == TouchPhase.Ended)
//				{
//					leftTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = leftTurnScreenPointRelease;				
//					move = 0;
//					leftMove = -1;
//					isLeftArrowPressed = false;
//				//	CameraRotation.isBtnClicked = false;
//				}
//				leftMove = i;
//			}
//			else if(leftMove == i){
//				leftTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = leftTurnScreenPointRelease;				
//				move = 0;
//				leftMove = -1;
//				isLeftArrowPressed = false;
//			}
//		
//			if((rightTurnScreenPoint.x < (Input.GetTouch(i).position.x + 120) && rightTurnScreenPoint.x > (Input.GetTouch(i).position.x - 200)) && 
//			(rightTurnScreenPoint.y < (Input.GetTouch(i).position.y + 130) && rightTurnScreenPoint.y > (Input.GetTouch(i).position.y - 130)))
//			{
//				CameraRotation.isBtnClicked = true;
//				if(Input.GetTouch(i).phase == TouchPhase.Began)
//				{
//					move = 1;
//						rightTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = rightTurnScreenPointPress;
//						leftTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = leftTurnScreenPointRelease;			
//				}
//				if(Input.GetTouch(i).phase == TouchPhase.Moved)
//				{
//					move = 1;
//					if(!isRightArrowPressed)
//					{
//						isRightArrowPressed = true;
//						rightTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = rightTurnScreenPointPress;
//						leftTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = leftTurnScreenPointRelease;			
//					}
//				}
//				
//				if(Input.GetTouch(i).phase == TouchPhase.Ended)
//				{
//					move = 0;
//					rightTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = rightTurnScreenPointRelease;
//					rightMove = -1;
//					isRightArrowPressed = false;
//				//	CameraRotation.isBtnClicked = false;
//				}
//				rightMove = i;
//				
//			}
//			else if(rightMove==i){
//				rightTurnScreenTransform.GetComponent<Renderer>().material.mainTexture = rightTurnScreenPointRelease;			
//				move = 0;
//				rightMove = -1;
//				isRightArrowPressed = false;
//			}	  
//		}
//	}

	
}