﻿#pragma strict
import System.Collections.Generic;
@script RequireComponent(VehicleParent)

//Class for detecting stunts
public class StuntDetect extends MonoBehaviour
{
	private var tr : Transform;
	private var rb: Rigidbody;
	private var vp : VehicleParent;

	@System.NonSerialized
	var score : float;
	private var stunts : List.<Stunt> = new List.<Stunt>();
	private var doneStunts : List.<Stunt> = new List.<Stunt>();
	private var drifting : boolean;
	private var driftDist : float;
	private var driftScore : float;
	private var endDriftTime : float;//Time during which drifting counts even if the vehicle is not actually drifting
	private var jumpDist : float;
	private var jumpTime : float;
	private var jumpStart : Vector3;

	var detectDrift : boolean = true;
	var detectJump : boolean = true;
	var detectFlips : boolean = true;

	private var driftString : String;//String indicating drift distance
	private var jumpString : String;//String indicating jump distance
	private var flipString : String;//String indicating flips
	@System.NonSerialized
	var stuntString : String;//String containing all stunts

	var engine : Motor;

	function Start()
	{
		tr = transform;
		rb = GetComponent(Rigidbody);
		vp = GetComponent(VehicleParent);
	}

	function FixedUpdate()
	{
		//Detect drifts
		if (detectDrift && !vp.crashing)
		{
			DetectDrift();
		}
		else
		{
			drifting = false;
			driftDist = 0;
			driftScore = 0;
			driftString = "";
		}

		//Detect jumps
		if (detectJump && !vp.crashing)
		{
			DetectJump();
		}
		else
		{
			jumpTime = 0;
			jumpDist = 0;
			jumpString = "";
		}

		//Detect flips
		if (detectFlips && !vp.crashing)
		{
			DetectFlips();
		}
		else
		{
			stunts.Clear();
			flipString = "";
		}

		//Combine strings into final stunt string
		stuntString = vp.crashing ? "Crashed" : driftString + jumpString + (String.IsNullOrEmpty(flipString) || String.IsNullOrEmpty(jumpString) ? "" : " + ") + flipString;
	}

	function DetectDrift()
	{
		endDriftTime = vp.groundedWheels > 0 ? (Mathf.Abs(vp.localVelocity.x) > 5 ? StuntManager.driftConnectDelayStatic : Mathf.Max(0, endDriftTime - Time.timeScale)) : 0;
		drifting = endDriftTime > 0;

		if (drifting)
		{
			driftScore += (StuntManager.driftScoreRateStatic * Mathf.Abs(vp.localVelocity.x)) * Time.timeScale;
			driftDist += vp.velMag * Time.fixedDeltaTime;
			driftString = "Drift: " + driftDist.ToString("n0") + " m";

			if (engine)
			{
				engine.boost += (StuntManager.driftBoostAddStatic * Mathf.Abs(vp.localVelocity.x)) * Time.timeScale * 0.0002f;
			}
		}
		else
		{
			score += driftScore;
			driftDist = 0;
			driftScore = 0;
			driftString = "";
		}
	}

	function DetectJump()
	{
		if (vp.groundedWheels == 0)
		{
			jumpDist = Vector3.Distance(jumpStart, tr.position);
			jumpTime += Time.fixedDeltaTime;
			jumpString = "Jump: " + jumpDist.ToString("n0") + " m";

			if (engine)
			{
				engine.boost += StuntManager.jumpBoostAddStatic * Time.timeScale * 0.01f;
			}
		}
		else
		{
			score += (jumpDist + jumpTime) * StuntManager.jumpScoreRateStatic;

			if (engine)
			{
				engine.boost += (jumpDist + jumpTime) * StuntManager.jumpBoostAddStatic * Time.timeScale * 0.01f;
			}

			jumpStart = tr.position;
			jumpDist = 0;
			jumpTime = 0;
			jumpString = "";
		}
	}

	function DetectFlips()
	{
		if (vp.groundedWheels == 0)
		{
			//Check to see if vehicle is performing a stunt and add it to the stunts list
			for (var curStunt : Stunt in StuntManager.stuntsStatic)
			{
				if (Vector3.Dot(vp.localAngularVel.normalized, curStunt.rotationAxis) >= curStunt.precision)
				{
					var stuntExists : boolean = false;
					
					for (var checkStunt : Stunt in stunts)
					{
						if (curStunt.name == checkStunt.name)
						{
							stuntExists = true;
							break;
						}
					}

					if (!stuntExists)
					{
						stunts.Add(new Stunt(curStunt));
					}
				}
			}

			flipString = "";

			//Check the progress of stunts and compile the flip string listing all stunts
			for (var curStunt2 : Stunt in stunts)
			{
				if (Vector3.Dot(vp.localAngularVel.normalized, curStunt2.rotationAxis) >= curStunt2.precision)
				{
					curStunt2.progress += rb.angularVelocity.magnitude * Time.fixedDeltaTime;
				}
				
				if (curStunt2.progress * Mathf.Rad2Deg >= curStunt2.angleThreshold)
				{
					var stuntDoneExists : boolean = false;

					for (var curDoneStunt : Stunt in doneStunts)
					{
						if (curDoneStunt == curStunt2)
						{
							stuntDoneExists = true;
							break;
						}
					}

					if (!stuntDoneExists)
					{
						doneStunts.Add(curStunt2);
					}
				}
			}
			
			var stuntCount : String = "";
			flipString = "";

			for (var curDoneStunt2 : Stunt in doneStunts)
			{
				stuntCount = curDoneStunt2.progress * Mathf.Rad2Deg >= curDoneStunt2.angleThreshold * 2 ? " x" + Mathf.FloorToInt((curDoneStunt2.progress * Mathf.Rad2Deg) / curDoneStunt2.angleThreshold).ToString() : "";
				flipString = String.IsNullOrEmpty(flipString) ? curDoneStunt2.name + stuntCount : flipString + " + " + curDoneStunt2.name + stuntCount;
			}
		}
		else
		{
			//Add stunt points to the score
			for (var curStunt : Stunt in stunts)
			{
				score += curStunt.progress * Mathf.Rad2Deg * curStunt.scoreRate * Mathf.FloorToInt((curStunt.progress * Mathf.Rad2Deg) / curStunt.angleThreshold) * curStunt.multiplier;

				//Add boost to the engine
				if (engine)
				{
					engine.boost += curStunt.progress * Mathf.Rad2Deg * curStunt.boostAdd * curStunt.multiplier * 0.01f;
				}
			}

			stunts.Clear();
			doneStunts.Clear();
			flipString = "";
		}
	}
}