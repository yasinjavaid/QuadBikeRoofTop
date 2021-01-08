using UnityEngine;
using System.Collections;

public static class DebugNew {
	

	public static void Log(object msg)
	{
		if(!Constants.isMarketReadyBuild)
		{
			Debug.Log(msg);
		}
	}

	public static void LogError(object msg)
	{
		if(!Constants.isMarketReadyBuild)
		{
			Debug.LogError(msg);
		}
	}

	public static void LogWarning(object msg)
	{
		if(!Constants.isMarketReadyBuild)
		{
			Debug.LogWarning(msg);
		}
	}

}
