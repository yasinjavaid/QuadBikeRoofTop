using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Globalization;
using System;
using Prime31;
//using MiniJSON;
using System.Security.Cryptography;

public class StoreManager : SingeltonBase<StoreManager> {
	
	string signed_data ;
	GameObject spinnerGameObject;
	string productPackageName;
	# if UNITY_IPHONE
	string purchasedProductId;
	string [] productIdentifiers = {ConstantsNew.PACKAGE_1,ConstantsNew.PACKAGE_2,ConstantsNew.PACKAGE_3,ConstantsNew.PACKAGE_4,ConstantsNew.PACKAGE_5,ConstantsNew.PACKAGE_VGP,ConstantsNew.UNLOCKALLEPISODE, ConstantsNew.UNLOCKALLVEHICLE, ConstantsNew.UNLOCKALL };
	bool canMakePayments = false;	
	# endif
	# if UNITY_ANDROID
	string [] productIdentifiers = {ConstantsNew.PACKAGE_1,ConstantsNew.PACKAGE_2,ConstantsNew.PACKAGE_3,ConstantsNew.PACKAGE_4,ConstantsNew.PACKAGE_5,ConstantsNew.PACKAGE_VGP };
	string [] managedProductIdentifiers = {Constants.REMOVEADS,Constants.UNLOCKALLEPISODE, Constants.UNLOCKALLVEHICLE, Constants.UNLOCKALL  };  	
	//		bool isRestoreTransaction = false;
	# endif
	
	public static string InApp_signature="";
	public static string InApp_purchaseData="";
	
	public static string packageId="";
	
	public void PurchasePackage(string packageName){
		productPackageName = packageName;
		UserPrefs.isEmptyTransaction=false;
		UserPrefs.isRestoreTransaction = false;		
		
		//		spinnerGameObject=Instantiate(Resources.Load("MenusNew/SubMenusNew/Spinner")) as GameObject;
		//		spinnerGameObject.GetComponent<SpinnerMenuHandler>().SetText("Please wait...");
		
		
		#if UNITY_EDITOR
		GameManager.Instance.PurchaseProductResult(packageName, true);
		#endif
		//		# if UNITY_IPHONE
		//		if(canMakePayments)
		//		{
		//			StoreKitBinding.purchaseProduct(packageName,1);
		//		}
		//		# endif
		
		# if UNITY_ANDROID
		if(UserPrefs.isAmazonBuild){
			//AmazonIAP.initiatePurchaseRequest(packageName);
		} 
		else {
			if(!isNonConsumedItem(packageName)){
				GoogleIAB.consumeProduct(packageName);	
			}
			packageId=packageName;
			GoogleIAB.purchaseProduct(packageName);
		}
		
		# endif
	}
	
	// Used for Restoring Transactions from Store.
	
	public void RestoreCompletedTransactions(){
		//		# if UNITY_IPHONE
		//		if(canMakePayments)
		//		{
		//			StoreKitBinding.restoreCompletedTransactions();
		//			
		//		}
		//		# endif
		
		# if UNITY_ANDROID
		UserPrefs.isRestoreTransaction = true;			
		if(UserPrefs.isAmazonBuild){
			//				AmazonIAP.initiateItemDataRequest(managedProductIdentifiers);
		} else {
			GoogleIAB.queryInventory(productIdentifiers);
		}
		# endif
	}
	
	// Used for Getting Product Identifier from Store.
	
	private void RequestProductIdentifier(){
		
		//		# if UNITY_IPHONE
		////		DebugNew.Log("Before Calling can make payment");
		//		canMakePayments = StoreKitBinding.canMakePayments();
		//		if(canMakePayments){
		//			StoreKitBinding.requestProductData(productIdentifiers);
		//		}	
		//		# endif
		
		# if UNITY_ANDROID
		if(UserPrefs.isAmazonBuild){
			UserPrefs.isRestoreTransaction = true;	
		//	AmazonIAP.initiateItemDataRequest(productIdentifiers);
		} else {
			GoogleIAB.init(Constants.INAPP_KEY);
			Invoke("queryInventory", 2.0f);
		}
		# endif
	}
	
	void queryInventory()
	{
		UserPrefs.isRestoreTransaction = true;
		GoogleIAB.queryInventory(productIdentifiers);
		
		Invoke("ConsumeProducts", 2.0f);
	}
	
	void Start(){
		this.RequestProductIdentifier();
	}
	
	//	# if UNITY_IPHONE
	//	
	//	void OnEnable()
	//	{
	//		// Listens to all the StoreKit events.  All event listeners MUST be removed before this object is disposed!
	//		StoreKitManager.purchaseSuccessfulEvent += purchaseSuccessful;
	//		StoreKitManager.purchaseCancelledEvent += purchaseCancelled;
	//		StoreKitManager.purchaseFailedEvent += purchaseFailed;
	//	}
	//	
	//	
	//	void OnDisable()
	//	{
	//		// Remove all the event handlers
	//		StoreKitManager.purchaseSuccessfulEvent -= purchaseSuccessful;
	//		StoreKitManager.purchaseCancelledEvent -= purchaseCancelled;
	//		StoreKitManager.purchaseFailedEvent -= purchaseFailed;
	//	}
	//	
	//	void purchaseFailed( string error )
	//	{
	////		DebugNew.Log( "purchase failed with error: " + error );
	//		GameManager.Instance.PurchaseProductResult(error, false);
	//	}
	//	
	//	void purchaseCancelled( string error )
	//	{
	//		GameManager.Instance.PurchaseProductResult("Purchased Canceled", false);
	////		DebugNew.Log( "purchase cancelled with error: " + error );
	//	}
	//	
	//	void restoreTransactionsFailed( string error )
	//	{
	////		DebugNew.Log( "restoreTransactionsFailed: " + error );
	//	}
	//	
	//	void restoreTransactionsFinished()
	//	{
	////		DebugNew.Log( "restoreTransactionsFinished" );
	//	}
	//	
	//	void purchaseSuccessful( StoreKitTransaction transaction )
	//	{
	//		purchasedProductId =  transaction.productIdentifier;
	//		verifyReceipt(Constants.receiptVerifySandboxURL,transaction);
	//	}
	//	
	//	public WWW verifyReceipt(string url, StoreKitTransaction transaction)
	//	{
	//		//string jsonString = String.Format("\"receipt-data\" : {0}, \"game_id\" : {1}",  transaction.base64EncodedTransactionReceipt,"\"5\"");
	//		string jsonString = String.Format("\"inapp_receipt\" : {0}, \"game_id\" : {1}", "\"" +transaction.base64EncodedTransactionReceipt+ "\"","\"" + Constants.iOS_IAP_Verification_ID + "\"" );jsonString =  String.Format("{{{0}}}", jsonString);
	////		DebugNew.LogError ("verifyReceipt: "+jsonString + "end of json string");
	//		Hashtable postHeader = new Hashtable();
	//		postHeader.Add("Content-Type", "application/json");  
	//		System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
	//		WWW www = new WWW(url,encoding.GetBytes(jsonString),postHeader);
	//		StartCoroutine(WaitForRequest(www));
	//		return www; 
	//	}
	//	
	//	private IEnumerator WaitForRequest(WWW www)
	//	{
	//		yield return www;
	////		DebugNew.Log("++++++++***********++    "+www.error);
	//		if (www.error == null)
	//		{
	//			string response = www.text; 
	////			DebugNew.Log("+++++++++++++++++++++++++++    " + response);
	//			IDictionary search = (IDictionary) MiniJSON.jsonDecode(response);// .Deserialize(response);
	////			DebugNew.Log("Debugging for dictionary    " + search["receipt"]);
	//			if(search["receipt"]!=null)
	//			{
	//				IDictionary receiptDic = (IDictionary) search["receipt"];
	//				//DateTime transDate = DateTime.SpecifyKind(DateTime.Parse(receiptDic["purchase_date"].ToString().Replace("\"", "").Replace("Etc/GMT", "")), DateTimeKind.Utc);
	//				//TimeSpan delay = DateTime.UtcNow - transDate; 
	////				DebugNew.Log("Debugging for dictionary    " + search["receipt"]);
	//				if((search["status"].ToString().Equals("0")) 
	//				   && (receiptDic["bid"].ToString().Equals( Constants.BundleID ))
	//				   && (receiptDic["product_id"].ToString().Equals(purchasedProductId)))
	//				{  
	//					GameManager.Instance.PurchaseProductResult(receiptDic["product_id"].ToString(), true);
	//					purchasedProductId = "";
	////					DebugNew.Log("Purchase successful with Product_id: " + receiptDic["product_id"].ToString());
	//				}
	//				else
	//				{
	//					GAManager.Instance.LogDesignEvent("User Made a fake purchase against Product_id: " + receiptDic["product_id"].ToString());
	////					DebugNew.Log("Fake Purchase");
	//				} 
	//			}
	//		}  
	//		else 
	//		{
	////			DebugNew.Log("error:"+www.error);  
	//		}     
	//	}
	//	
	//	# endif
	
	
	#if UNITY_ANDROID
	public WWW verifyReceiptForAndroid(string purchaseData, string signature )
	{ 
		InApp_purchaseData = purchaseData;
		InApp_signature = signature;
		
		string hash=CalculateMD5Hash(purchaseData);
		
		string itemType;
		itemType = "unmanaged";
		
		string encodedData = WWW.EscapeURL(purchaseData);//System.Text.Encoding.UTF8.GetString(purchaseData);
		signed_data=encodedData;
		string jsonString = String.Format("\"api_key\" : {0}, \"game_package\" : {1} , \"hash\" : {2} , \"signature\" : {3} , \"signed_data\" : {4}, \"itemType\" : {5}", "\"" +  "333502605316711101" +"\"", "\"" +Constants.Bundle_ID +"\"", "\"" +hash +"\"", "\"" +signature +"\"", "\"" +encodedData+"\"", "\"" +itemType +"\"");
		
		jsonString =  String.Format("{{{0}}}", jsonString);
		//		DebugNew.LogError ("verifyReceipt: "+jsonString + "end of /json string");
		Dictionary<string,string> postHeader = new Dictionary<string,string>();
		postHeader.Add("Content-Type", "application/json");  
		System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
		WWW www = new WWW(Constants.receiptVerifyLiveURL,encoding.GetBytes(jsonString),postHeader);
		
		StartCoroutine(WaitForRequest(www));
		return www;
	}
	
	public string CalculateMD5Hash(string input)
	{
		// step 1, calculate MD5 hash from input
		MD5 md5 = System.Security.Cryptography.MD5.Create();
		byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
		byte[] hash = md5.ComputeHash(inputBytes);
		
		// step 2, convert byte array to hex string
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < hash.Length; i++)
		{
			sb.Append(hash[i].ToString("X2"));
		}
		return sb.ToString();
	}
	
	public string Md5HashKey(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);
		
		// encrypt bytes
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);
		
		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";
		
		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}
		
		return hashString.PadLeft(32, '0');
	}
	
	private IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		//		DebugNew.Log("++++++++***********++    "+www.error);
		if (www.error == null)
		{
			string response = www.text; 
			IDictionary search = (IDictionary) MiniJson2.jsonDecode(response);// .Deserialize(response);
			String statusCode = (String) search["status_code"];
			
			String hashCode = (String) search["gamedata"];
			string MD5hashkeystring = Md5HashKey(signed_data+Constants.IAP_secret_key);
			DebugNew.Log("Inapp Verifcation: status code = "+statusCode+" Hash code = "+hashCode + ", Local hashkey = "+MD5hashkeystring);
			
			if(hashCode.Equals(MD5hashkeystring))
			{
				//Purchase successfully verified
				if(statusCode.Equals("001"))
				{
					if(!UserPrefs.isAmazonBuild && !isNonConsumedItem(packageId)){
						GoogleIAB.consumeProduct(packageId);
					}
					GameManager.Instance.PurchaseProductResult(packageId, true);
					InApp_purchaseData = "";
					InApp_signature = "";
					
					DebugNew.Log("Purchase successful with Product_id: " + packageId);
					packageId="";
					
				}
				else if(statusCode.Equals("7"))
				{
					DebugNew.LogError("MyTest : WaitForRequest");
				}
				
			}
			else
			{
				if(!UserPrefs.isAmazonBuild && !isNonConsumedItem(packageId)){
					GoogleIAB.consumeProduct(packageId);
				}
				GAManager.Instance.LogDesignEvent("FakePurchase Product_id: " + packageId + " status code "+ statusCode);
				DebugNew.Log("Fake Purchase");
				GameManager.Instance.PurchaseProductResult(packageId, true);
			}
		}
	}
	
	
	
	
	#region Common InApp
	void OnEnable()
	{
		//		if(UserPrefs.isAmazonBuild){
		//			// Listen to all events for illustration purposes
		//			AmazonIAPManager.itemDataRequestFailedEvent += itemDataRequestFailedEvent;
		//			AmazonIAPManager.itemDataRequestFinishedEvent += itemDataRequestFinishedEvent;
		//			AmazonIAPManager.purchaseFailedEvent += purchaseFailedEvent;
		//			AmazonIAPManager.purchaseSuccessfulEvent += purchaseSuccessfulEvent;
		//			AmazonIAPManager.purchaseUpdatesRequestFailedEvent += purchaseUpdatesRequestFailedEvent;
		//			AmazonIAPManager.purchaseUpdatesRequestSuccessfulEvent += purchaseUpdatesRequestSuccessfulEvent;
		//			AmazonIAPManager.onSdkAvailableEvent += onSdkAvailableEvent;
		//			AmazonIAPManager.onGetUserIdResponseEvent += onGetUserIdResponseEvent;
		//		} else {
		// Listen to all events for illustration purposes
		GoogleIABManager.billingSupportedEvent += billingSupportedEvent;
		GoogleIABManager.billingNotSupportedEvent += billingNotSupportedEvent;
		GoogleIABManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
		GoogleIABManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
		GoogleIABManager.purchaseCompleteAwaitingVerificationEvent += purchaseCompleteAwaitingVerificationEvent;
		GoogleIABManager.purchaseSucceededEvent += purchaseSucceededEvent;
		GoogleIABManager.purchaseFailedEvent += purchaseFailedEvent;
		GoogleIABManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
		GoogleIABManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;
		//		}
	}
	
	
	void OnDisable()
	{
		//		if(UserPrefs.isAmazonBuild){
		//			// Remove all event handlers
		//			AmazonIAPManager.itemDataRequestFailedEvent -= itemDataRequestFailedEvent;
		//			AmazonIAPManager.itemDataRequestFinishedEvent -= itemDataRequestFinishedEvent;
		//			AmazonIAPManager.purchaseFailedEvent -= purchaseFailedEvent;
		//			AmazonIAPManager.purchaseSuccessfulEvent -= purchaseSuccessfulEvent;
		//			AmazonIAPManager.purchaseUpdatesRequestFailedEvent -= purchaseUpdatesRequestFailedEvent;
		//			AmazonIAPManager.purchaseUpdatesRequestSuccessfulEvent -= purchaseUpdatesRequestSuccessfulEvent;
		//			AmazonIAPManager.onSdkAvailableEvent -= onSdkAvailableEvent;
		//			AmazonIAPManager.onGetUserIdResponseEvent -= onGetUserIdResponseEvent;
		//		} else {
		// Remove all event handlers
		GoogleIABManager.billingSupportedEvent -= billingSupportedEvent;
		GoogleIABManager.billingNotSupportedEvent -= billingNotSupportedEvent;
		GoogleIABManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
		GoogleIABManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
		GoogleIABManager.purchaseCompleteAwaitingVerificationEvent += purchaseCompleteAwaitingVerificationEvent;
		GoogleIABManager.purchaseSucceededEvent -= purchaseSucceededEvent;
		GoogleIABManager.purchaseFailedEvent -= purchaseFailedEvent;
		GoogleIABManager.consumePurchaseSucceededEvent -= consumePurchaseSucceededEvent;
		GoogleIABManager.consumePurchaseFailedEvent -= consumePurchaseFailedEvent;
		//		}
	}
	
	void purchaseFailedEvent( string error, int response1 )
	{
		DebugNew.Log( "purchaseFailedEvent: " + error + "  response : "+response1 );
		
		string response = error; 
		try{
			if(response1!=-1005)//(-1005) means user pressed back button i.e cancelled.
			{
				IDictionary search = (IDictionary) MiniJSON.jsonDecode(response);// .Deserialize(response);
				String statusCode = search["response"].ToString();
				
				if (statusCode.Equals ("7")) {
					RestoreCompletedTransactions();
				}
			}
			else{
				GameManager.Instance.PurchaseProductResult(productPackageName, false);
			}
		}
		catch(Exception ex)
		{
			DebugNew.LogWarning("Exception Store Manager :: purchaseFailedEvent");
			GameManager.Instance.PurchaseProductResult(productPackageName, false);
		}
		
		//		GameManager.Instance.PurchaseProductResult(productPackageName, false, false, null, null, spinnerGameObject);
		
	}
	
	bool isNonConsumedItem(string packageName)
	{
		bool isNonConsumed = false;
		
		for(int i = 0; i < managedProductIdentifiers.Length; i++){
			if(managedProductIdentifiers[i] == packageName ){
				isNonConsumed = true;
				break;
			}
		}
		
		return isNonConsumed;
	}
	void ConsumeProducts()
	{
		GoogleIAB.consumeProducts (managedProductIdentifiers);
	}
	
	#endregion
	
	#region Google InApp
	void billingSupportedEvent()
	{
		DebugNew.Log( "billingSupportedEvent" );
	}
	
	
	void billingNotSupportedEvent( string error )
	{
		DebugNew.Log( "billingNotSupportedEvent: " + error );
	}
	
	void queryInventorySucceededEvent( List<GooglePurchase> purchases, List<GoogleSkuInfo> skus )
	{
		//		DebugNew.Log( string.Format( "queryInventorySucceededEvent. total purchases: {0}, total skus: {1}", purchases.Count, skus.Count ) );
		if(!Constants.isMarketReadyBuild)
		{
			Prime31.Utils.logObject( purchases );
			Prime31.Utils.logObject( skus );
		}
		
		if(UserPrefs.isRestoreTransaction && purchases != null){
			
			for(int i=0; i<purchases.Count; i++){					
				//				DebugNew.Log("<<>>SkuPurchases:"+purchases[i].productId);
				if(i==0){
					//					Instantiate(Resources.Load("SubMenusNew/RestoreSuccessfullPopUp"));
					//					RestoreMsgListner.msgType=3;
				}
				if(isNonConsumedItem(purchases[i].productId)){
					purchaseSucceededEvent(purchases[i]);
					UserPrefs.isRestoreTransaction = false;
				}						
			}
			
			UserPrefs.isRestoreTransaction = false;
			
			if(purchases.Count<1){
				UserPrefs.isEmptyTransaction=true;
				//				Instantiate(Resources.Load("SubMenusNew/RestoreSuccessfullPopUp"));
				//				RestoreMsgListner.msgType=5;
			}
		}
	}
	
	
	void queryInventoryFailedEvent( string error )
	{
		UserPrefs.isRestoreTransaction = false;
		DebugNew.Log( "queryInventoryFailedEvent: " + error );
		
		//		Instantiate(Resources.Load("SubMenusNew/RestoreSuccessfullPopUp"));
		//		RestoreMsgListner.msgType=5;
	}
	
	
	void purchaseCompleteAwaitingVerificationEvent( string purchaseData, string signature )
	{
		InApp_purchaseData = purchaseData;
		InApp_signature = signature;
		//		spinnerGameObject.GetComponent<SpinnerMenuHandler>().SetText("Verifying Purchase...");
		DebugNew.Log( "purchaseCompleteAwaitingVerificationEvent. purchaseData: " + purchaseData + ", signature: " + signature );
		if(!packageId.Equals("android.test.purchased"))
			verifyReceiptForAndroid(purchaseData,signature);
	}
	
	void purchaseSucceededEvent( GooglePurchase purchase )
	{
		DebugNew.Log( "purchaseSucceededEvent: " + purchase );
	}
	
	void consumePurchaseSucceededEvent( GooglePurchase purchase )
	{
		DebugNew.Log( "consumePurchaseSucceededEvent: " + purchase );
	}
	
	void consumePurchaseFailedEvent( string error )
	{
		DebugNew.Log( "consumePurchaseFailedEvent: " + error );
	}
	
	#endregion
	
	#endif
	
}