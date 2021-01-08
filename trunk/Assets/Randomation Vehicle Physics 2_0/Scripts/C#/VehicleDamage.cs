﻿using UnityEngine;
using System.Collections;
[RequireComponent(typeof(VehicleParent))]

//Class for damaging vehicles
public class VehicleDamage : MonoBehaviour
{
	Transform tr;
	Rigidbody rb;
	VehicleParent vp;

	[RangeAttribute(0, 1)]
	public float strength = 1;
	public float damageFactor = 1;

	public float maxCollisionMagnitude = 100;
	
	[Tooltip("Maximum collision points to use when deforming, has large effect on performance")]
	public int maxCollisionPoints = 2;

	[Tooltip("Collisions underneath this local y-position will be ignored")]
	public float collisionIgnoreHeight;

	[Tooltip("If true, grounded wheels will not be damaged, but can still be displaced")]
	public bool ignoreGroundedWheels;

	[Tooltip("Minimum time in seconds between collisions")]
	public float collisionTimeGap = 0.1f;
	float hitTime;

	[Tooltip("Whether the edges of adjacent deforming parts should match")]
	public bool seamlessDeform;

	[Tooltip("Add some perlin noise to deformation")]
	public bool usePerlinNoise = true;

	[Tooltip("Recalculate normals of deformed meshes")]
	public bool calculateNormals = true;

	[Tooltip("Parts that are damaged")]
	public Transform[] damageParts;

	[Tooltip("Meshes that are deformed")]
	public MeshFilter[] deformMeshes;
	bool[] damagedMeshes;
	Mesh[] tempMeshes;
	meshVerts[] meshVertices;

	[Tooltip("Mesh colliders that are deformed (Poor performance, must be convex)")]
	public MeshCollider[] deformColliders;
	bool[] damagedCols;
	Mesh[] tempCols;
	meshVerts[] colVertices;

	[Tooltip("Parts that are displaced")]
	public Transform[] displaceParts;
	Vector3[] initialPartPositions;

	void Start()
	{
		tr = transform;
		rb = GetComponent<Rigidbody>();
		vp = GetComponent<VehicleParent>();

		if (transform.root.gameObject.tag == "Player2") {
			strength = strength + Constants.PlayerCarHealth [UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1];
			if(strength>1||strength==1)
				strength=0.8f;
			
			
			
		} else {
			strength = strength + Constants.EnemyCarsHealth [UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1];
			if(strength>1)
				strength=0.99f;
		}
		//Tell VehicleParent not to play crashing sounds because this script takes care of it
		vp.playCrashSounds = false;
		vp.playCrashSparks = false;

		//Set up mesh data
		tempMeshes = new Mesh[deformMeshes.Length];
		damagedMeshes = new bool[deformMeshes.Length];
		meshVertices = new meshVerts[deformMeshes.Length];
		for (int i = 0; i < deformMeshes.Length; i++)
		{
			tempMeshes[i] = deformMeshes[i].mesh;
			meshVertices[i] = new meshVerts();
			meshVertices[i].verts = deformMeshes[i].mesh.vertices;
			meshVertices[i].initialVerts = deformMeshes[i].mesh.vertices;
			damagedMeshes[i] = false;
		}

		//Set up mesh collider data
		tempCols = new Mesh[deformColliders.Length];
		damagedCols = new bool[deformColliders.Length];
		colVertices = new meshVerts[deformColliders.Length];
		for (int i = 0; i < deformColliders.Length; i++)
		{
			tempCols[i] = (Mesh)Instantiate(deformColliders[i].sharedMesh);
			colVertices[i] = new meshVerts();
			colVertices[i].verts = deformColliders[i].sharedMesh.vertices;
			colVertices[i].initialVerts = deformColliders[i].sharedMesh.vertices;
			damagedCols[i] = false;
		}

		//Set initial positions for displaced parts
		initialPartPositions = new Vector3[displaceParts.Length];
		for (int i = 0; i < displaceParts.Length; i++)
		{
			initialPartPositions[i] = displaceParts[i].localPosition;
		}
	}

	void FixedUpdate()
	{
		//Decrease timer for collisionTimeGap
		hitTime = Mathf.Max(0, hitTime - Time.fixedDeltaTime);
		//Make sure damageFactor is not negative
		damageFactor = Mathf.Max(0, damageFactor);
	}

	//Apply damage on collision
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name=="Destroy"||col.gameObject.name=="Water")
		{
			Motor damagedMotor = damageParts[0].GetComponent<Motor>();
			damagedMotor.health =0.0f;
			
		}
		if (hitTime == 0 && col.relativeVelocity.sqrMagnitude * damageFactor > 1 && strength < 1)
		{
			float colMag = Mathf.Min(col.relativeVelocity.magnitude, maxCollisionMagnitude) * (1 - strength) * damageFactor;//Magnitude of collision
			
			Motor damagedMotor = damageParts[0].GetComponent<Motor>();

			if(col.gameObject.tag!="Surface" && col.gameObject.GetComponent<Rigidbody>()!=null&&col.gameObject.tag!="wall" )
				if(col.gameObject.GetComponent<Rigidbody>().mass<10000)
			{
				if (damagedMotor&&col.relativeVelocity.magnitude>rb.velocity.magnitude)
				{
					float DamageFactor = 0.035f*colMag * (1 - damagedMotor.strength);

					if(this.tag=="Player2")
					{
						if(UserPrefs.currentEpisode==1&&UserPrefs.currentLevel<4)
						{
							Constants.PlayerCarThreshold=0.08f;

						}
						else
						{

							Constants.PlayerCarThreshold=0.2f;

						}

						if(DamageFactor<Constants.PlayerCarThreshold)

							damagedMotor.health-=DamageFactor;
						else
							damagedMotor.health-=Constants.PlayerCarThreshold;
						
					}
					else
					{
						if(UserPrefs.currentVehicle==2)
						{
							DamageFactor+=0.02f;
						}
						if(UserPrefs.currentVehicle==3)
						{
							DamageFactor+=0.03f;
						}
						if(UserPrefs.currentVehicle==4)
						{
							DamageFactor+=0.05f;
						}
						if(UserPrefs.currentVehicle==5)
						{
							DamageFactor+=0.08f;
						}

						if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1==1)
							DamageFactor+=0.03f;
						if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1==2)
							DamageFactor+=0.05f;
						if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1==3)
							DamageFactor+=0.07f;
						if(DamageFactor<Constants.EnemyCarThreshold)
							damagedMotor.health-=DamageFactor;
						else
							damagedMotor.health-=Constants.EnemyCarThreshold;
						
						
						
					}
				}
			}
			else{
				
				if (damagedMotor)
					
					
				{
					
					float DamageFactor;                                                                                                                                                                                                                                                                  
					if(this.tag=="Player2")
					{
						DamageFactor = 0.035f*colMag * (1 - damagedMotor.strength); 
						if(UserPrefs.currentEpisode==1&&UserPrefs.currentLevel<4)
						{
							Constants.PlayerCarThreshold=0.08f;
							
						}
						else
						{
							
							Constants.PlayerCarThreshold=0.15f;
						}
						if(DamageFactor<Constants.PlayerCarThreshold)
							damagedMotor.health-=DamageFactor;
						else
							
							damagedMotor.health-=Constants.PlayerCarThreshold;
						
					}
					else
					{
						DamageFactor=0.03f*colMag*(1-damagedMotor.strength);
						if(UserPrefs.currentVehicle==2)
						{
							DamageFactor+=0.02f;
						}
						if(UserPrefs.currentVehicle==3)
						{
							DamageFactor+=0.03f;
						}
						if(UserPrefs.currentVehicle==4)
						{
							DamageFactor+=0.04f;
						}
						if(UserPrefs.currentVehicle==5)
						{
							DamageFactor+=0.05f;
						}
						if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1==1)
							DamageFactor+=0.05f;
						if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1==2)
							DamageFactor+=0.08f;
						if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1==3)
							DamageFactor+=0.1f;


						if(DamageFactor<Constants.EnemyCarThreshold)
							damagedMotor.health-=DamageFactor;
						else
							damagedMotor.health-=Constants.EnemyCarThreshold;
						
						
						
					}
				}


			}




			float clampedColMag = Mathf.Pow(Mathf.Sqrt(colMag) * 0.5f, 1.5f);//Clamped magnitude of collision
			Vector3 clampedVel = Vector3.ClampMagnitude(col.relativeVelocity, maxCollisionMagnitude);//Clamped velocity of collision
			Vector3 normalizedVel = col.relativeVelocity.normalized;
			Vector3 translation;
			Vector3 clampedTranslation;
			Vector3 localPos;
			float vertDist;
			float distClamp;
			float surfaceDot;//Dot production of collision velocity and surface normal
			float massFactor = 1;//Multiplier for damage based on mass of other rigidbody
			DetachablePart detachedPart;
			Suspension damagedSus;
			Transform seamKeeper = null;//Transform for maintaining seams on shattered parts
			Vector3 seamLocalPoint;
			Transform curDamagePart;
			float damagePartFactor;
			MeshFilter curDamageMesh;
			Transform curDisplacePart;
			Vector3 vertProjection;
			int colsChecked = 0;
			bool soundPlayed = false;
			bool sparkPlayed = false;
			hitTime = collisionTimeGap;

			foreach (ContactPoint curCol in col.contacts)
			{
				if (tr.InverseTransformPoint(curCol.point).y > collisionIgnoreHeight && GlobalControl.damageMaskStatic == (GlobalControl.damageMaskStatic | (1 << curCol.otherCollider.gameObject.layer)))
				{
					colsChecked ++;

					//Get mass factor for multiplying damage
					if (curCol.otherCollider.attachedRigidbody)
					{
						massFactor = Mathf.Clamp01(curCol.otherCollider.attachedRigidbody.mass/rb.mass );
					}

					//Play crash sound
					if (vp.crashSnd && vp.crashClips.Length > 0 && !soundPlayed)
					{
						vp.crashSnd.PlayOneShot(vp.crashClips[Mathf.RoundToInt(Random.Range(0, vp.crashClips.Length - 1))], Mathf.Clamp01(col.relativeVelocity.magnitude * 0.1f));
						soundPlayed = true;
					}

					//Play crash sparks
					if (vp.sparks && !sparkPlayed)
					{
						vp.sparks.transform.position = curCol.point;
						vp.sparks.transform.rotation = Quaternion.LookRotation(normalizedVel, curCol.normal);
						vp.sparks.Play();
						sparkPlayed = true;
					}

					surfaceDot = Mathf.Clamp01(Vector3.Dot(curCol.normal, normalizedVel)) * (Vector3.Dot((tr.position - curCol.point).normalized, normalizedVel) + 1) * 0.5f;

					//Damage damageable parts
					for (int i = 0; i < damageParts.Length; i++)
					{
						curDamagePart = damageParts[i];
						damagePartFactor = colMag * surfaceDot * massFactor * Mathf.Min(clampedColMag * 0.01f, (clampedColMag * 0.001f) / Mathf.Pow(Vector3.Distance(curDamagePart.position, curCol.point), clampedColMag));
//
//						//Damage motors
//						 damagedMotor = curDamagePart.GetComponent<Motor>();
//						if (damagedMotor)
//						{
//							damagedMotor.health -= damagePartFactor * (1 - damagedMotor.strength);
//						}

						//Damage transmissions
						Transmission damagedTransmission = curDamagePart.GetComponent<Transmission>();
						if (damagedTransmission)
						{
							damagedTransmission.health -= damagePartFactor * (1 - damagedTransmission.strength);
						}
					}

					//Deform meshes
					for (int i = 0; i < deformMeshes.Length; i++)
					{
						curDamageMesh = deformMeshes[i];
						localPos = curDamageMesh.transform.InverseTransformPoint(curCol.point);
						translation = curDamageMesh.transform.InverseTransformDirection(clampedVel);
						clampedTranslation = Vector3.ClampMagnitude(translation, clampedColMag);

//						//Shatter parts that can shatter
//						ShatterPart shattered = curDamageMesh.GetComponent<ShatterPart>();
//						if (shattered)
//						{
//							seamKeeper = shattered.seamKeeper;
//							if (Vector3.Distance(curDamageMesh.transform.position, curCol.point) < colMag * surfaceDot * 0.1f * massFactor && colMag * surfaceDot * massFactor > shattered.breakForce)
//							{
//								shattered.Shatter();
//							}
//						}

						//Actual deformation
						if (translation.sqrMagnitude > 0 && strength < 1)
						{
							for (int j = 0; j < meshVertices[i].verts.Length; j++)
							{
								vertDist = Vector3.Distance(meshVertices[i].verts[j], localPos);
								distClamp = (clampedColMag * 0.001f) / Mathf.Pow(vertDist, clampedColMag);

								if (distClamp > 0.001f)
								{
									damagedMeshes[i] = true;
									if (seamKeeper == null || seamlessDeform)
									{
										vertProjection = seamlessDeform ? Vector3.zero : Vector3.Project(normalizedVel, meshVertices[i].verts[j]);
										meshVertices[i].verts[j] += (clampedTranslation - vertProjection * (usePerlinNoise ? 1 + Mathf.PerlinNoise(meshVertices[i].verts[j].x * 100, meshVertices[i].verts[j].y * 100) : 1)) * surfaceDot * Mathf.Min(clampedColMag * 0.01f, distClamp) * massFactor;
									}
									else
									{
										seamLocalPoint = seamKeeper.InverseTransformPoint(curDamageMesh.transform.TransformPoint(meshVertices[i].verts[j]));
										meshVertices[i].verts[j] += (clampedTranslation - Vector3.Project(normalizedVel, seamLocalPoint) * (usePerlinNoise ? 1 + Mathf.PerlinNoise(seamLocalPoint.x * 100, seamLocalPoint.y * 100) : 1)) * surfaceDot * Mathf.Min(clampedColMag * 0.01f, distClamp) * massFactor;
									}
								}
							}
						}
					}

					seamKeeper = null;

//					//Deform mesh colliders
//					for (int i = 0; i < deformColliders.Length; i++)
//					{	
//						localPos = deformColliders[i].transform.InverseTransformPoint(curCol.point);
//						translation = deformColliders[i].transform.InverseTransformDirection(clampedVel);
//						clampedTranslation = Vector3.ClampMagnitude(translation, clampedColMag);
//						
//						if (translation.sqrMagnitude > 0 && strength < 1)
//						{
//							for (int j = 0; j < colVertices[i].verts.Length; j++)
//							{
//								vertDist = Vector3.Distance(colVertices[i].verts[j], localPos);
//								distClamp = (clampedColMag * 0.001f) / Mathf.Pow(vertDist, clampedColMag);
//
//								if (distClamp > 0.001f)
//								{
//									damagedCols[i] = true;
//									colVertices[i].verts[j] += clampedTranslation * surfaceDot * Mathf.Min(clampedColMag * 0.01f, distClamp) * massFactor;
//								}
//							}
//						}
//					}


					//Displace parts
					for (int i = 0; i < displaceParts.Length; i++)
					{
						curDisplacePart = displaceParts[i];
						translation = clampedVel;
						clampedTranslation = Vector3.ClampMagnitude(translation, clampedColMag);
						
						if (translation.sqrMagnitude > 0 && strength < 1)
						{
							vertDist = Vector3.Distance(curDisplacePart.position, curCol.point);
							distClamp = (clampedColMag * 0.001f) / Mathf.Pow(vertDist, clampedColMag);

							if (distClamp > 0.001f)
							{
								curDisplacePart.position += clampedTranslation * surfaceDot * Mathf.Min(clampedColMag * 0.01f, distClamp) * massFactor;

								//Detach detachable parts
								if (curDisplacePart.GetComponent<DetachablePart>())
								{
									detachedPart = curDisplacePart.GetComponent<DetachablePart>();

									if (colMag * surfaceDot * massFactor > detachedPart.looseForce && detachedPart.looseForce >= 0)
									{
										detachedPart.initialPos = curDisplacePart.localPosition;
										detachedPart.Detach(true);
									}
									else if (colMag * surfaceDot * massFactor > detachedPart.breakForce)
									{
										detachedPart.Detach(false);
									}
								}
								//Maybe the parent of this part is what actually detaches, useful for displacing compound colliders that represent single detachable objects
								else if (curDisplacePart.parent.GetComponent<DetachablePart>())
								{
									detachedPart = curDisplacePart.parent.GetComponent<DetachablePart>();

									if (!detachedPart.detached)
									{
										if (colMag * surfaceDot * massFactor > detachedPart.looseForce && detachedPart.looseForce >= 0)
										{
											detachedPart.initialPos = curDisplacePart.parent.localPosition;
											detachedPart.Detach(true);
										}
										else if (colMag * surfaceDot * massFactor > detachedPart.breakForce)
										{
											detachedPart.Detach(false);
										}
									}
									else if (detachedPart.hinge)
									{
										detachedPart.displacedAnchor += curDisplacePart.parent.InverseTransformDirection(clampedTranslation * surfaceDot * Mathf.Min(clampedColMag * 0.01f, distClamp) * massFactor);
									}
								}

								//Damage suspensions and wheels
								damagedSus = curDisplacePart.GetComponent<Suspension>();
								if (damagedSus)
								{
									if ((!damagedSus.wheel.grounded && ignoreGroundedWheels) || !ignoreGroundedWheels)
									{
										curDisplacePart.RotateAround(damagedSus.tr.TransformPoint(damagedSus.damagePivot), Vector3.ProjectOnPlane(curCol.point - curDisplacePart.position, -translation.normalized), clampedColMag * surfaceDot * distClamp * 20 * massFactor);

										damagedSus.wheel.damage += clampedColMag * surfaceDot * distClamp * 10 * massFactor;

										if (clampedColMag * surfaceDot * distClamp * 10 * massFactor > damagedSus.jamForce)
										{
											damagedSus.jammed = true;
										}

										if (clampedColMag * surfaceDot * distClamp * 10 * massFactor > damagedSus.wheel.detachForce)
										{
											damagedSus.wheel.Detach();
										}

										foreach (SuspensionPart curPart in damagedSus.movingParts)
										{
											if (curPart.connectObj && !curPart.isHub && !curPart.solidAxle)
											{
												if (!curPart.connectObj.GetComponent<SuspensionPart>())
												{
													curPart.connectPoint += curPart.connectObj.InverseTransformDirection(clampedTranslation * surfaceDot * Mathf.Min(clampedColMag * 0.01f, distClamp) * massFactor);
												}
											}
										}
									}
								}

								//Damage hover wheels
								HoverWheel damagedHoverWheel = curDisplacePart.GetComponent<HoverWheel>();
								if (damagedHoverWheel)
								{
									if ((!damagedHoverWheel.grounded && ignoreGroundedWheels) || !ignoreGroundedWheels)
									{
										if (clampedColMag * surfaceDot * distClamp * 10 * massFactor > damagedHoverWheel.detachForce)
										{
											damagedHoverWheel.Detach();
										}
									}
								}
							}
						}
					}
				}

				//Stop checking collision points when limit reached
				if (colsChecked >= maxCollisionPoints)
				{
					break;
				}
			}

			//Apply vertices to actual meshes
			for (int i = 0; i < deformMeshes.Length; i++)
			{
				if (damagedMeshes[i])
				{
					tempMeshes[i].vertices = meshVertices[i].verts;

					if (calculateNormals)
					{
						tempMeshes[i].RecalculateNormals();
					}

					tempMeshes[i].RecalculateBounds();
				}

				damagedMeshes[i] = false;
			}

//			//Apply vertices to actual mesh colliders
//			for (int i = 0; i < deformColliders.Length; i++)
//			{
//				if (damagedCols[i])
//				{
//					tempCols[i].vertices = colVertices[i].verts;
//					deformColliders[i].sharedMesh = null;
//					deformColliders[i].sharedMesh = tempCols[i];
//				}
//
//				damagedCols[i] = false;
//			}
		}
	}
	
	public void Repair()
	{
		//Fix damaged parts
		for (int i = 0; i < damageParts.Length; i++)
		{
			if (damageParts[i].GetComponent<Motor>())
			{
				damageParts[i].GetComponent<Motor>().health = 1;
			}

			if (damageParts[i].GetComponent<Transmission>())
			{
				damageParts[i].GetComponent<Transmission>().health = 1;
			}
		}

		//Restore deformed meshes
		for (int i = 0; i < deformMeshes.Length; i++)
		{
			for (int j = 0; j < meshVertices[i].verts.Length; j++)
			{
				meshVertices[i].verts[j] = meshVertices[i].initialVerts[j];
			}

			tempMeshes[i].vertices = meshVertices[i].verts;
			tempMeshes[i].RecalculateNormals();
			tempMeshes[i].RecalculateBounds();

			//Fix shattered parts
			ShatterPart fixedShatter = deformMeshes[i].GetComponent<ShatterPart>();
			if (fixedShatter)
			{
				fixedShatter.shattered = false;

				if (fixedShatter.brokenMaterial)
				{
					fixedShatter.rend.sharedMaterial = fixedShatter.initialMat;
				}
				else
				{
					fixedShatter.rend.enabled = true;
				}
			}
		}

		//Restore deformed mesh colliders
		for (int i = 0; i < deformColliders.Length; i++)
		{	
			for (int j = 0; j < colVertices[i].verts.Length; j++)
			{
				colVertices[i].verts[j] = colVertices[i].initialVerts[j];
			}

			tempCols[i].vertices = colVertices[i].verts;
			deformColliders[i].sharedMesh = null;
			deformColliders[i].sharedMesh = tempCols[i];
		}

		//Fix displaced parts
		Suspension fixedSus;
		Transform curDisplacePart;
		for (int i = 0; i < displaceParts.Length; i++)
		{
			curDisplacePart = displaceParts[i];
			curDisplacePart.localPosition = initialPartPositions[i];

			if (curDisplacePart.GetComponent<DetachablePart>())
			{
				curDisplacePart.GetComponent<DetachablePart>().Reattach();
			}
			else if (curDisplacePart.parent.GetComponent<DetachablePart>())
			{
				curDisplacePart.parent.GetComponent<DetachablePart>().Reattach();
			}

			fixedSus = curDisplacePart.GetComponent<Suspension>();
			if (fixedSus)
			{
				curDisplacePart.localRotation = fixedSus.initialRotation;
				fixedSus.jammed = false;

				foreach (SuspensionPart curPart in fixedSus.movingParts)
				{
					if (curPart.connectObj && !curPart.isHub && !curPart.solidAxle)
					{
						if (!curPart.connectObj.GetComponent<SuspensionPart>())
						{
							curPart.connectPoint = curPart.initialConnectPoint;
						}
					}
				}
			}
		}

		//Fix wheels
		foreach (Wheel curWheel in vp.wheels)
		{
			curWheel.Reattach();
			curWheel.FixTire();
			curWheel.damage = 0;
		}

		//Fix hover wheels
		foreach (HoverWheel curHoverWheel in vp.hoverWheels)
		{
			curHoverWheel.Reattach();
		}
	}

	//Draw collisionIgnoreHeight gizmos
	void OnDrawGizmosSelected()
	{
		Vector3 startPoint = transform.TransformPoint(Vector3.up * collisionIgnoreHeight);
		Gizmos.color = Color.red;
		Gizmos.DrawRay(startPoint, Vector3.forward);
		Gizmos.DrawRay(startPoint, Vector3.back);
		Gizmos.DrawRay(startPoint, Vector3.right);
		Gizmos.DrawRay(startPoint, Vector3.left);
	}

	//Destroy loose parts
	void OnDestroy()
	{
		foreach (Transform curPart in displaceParts)
		{
			if (curPart)
			{
				if (curPart.GetComponent<DetachablePart>() && curPart.parent == null)
				{
					Destroy(curPart.gameObject);
				}
				else if (curPart.parent.GetComponent<DetachablePart>() && curPart.parent.parent == null)
				{
					Destroy(curPart.parent.gameObject);
				}
			}
		}
	}
}

//Class for easier mesh data manipulation
class meshVerts
{
	public Vector3[] verts;//Current mesh vertices
	public Vector3[] initialVerts;//Original mesh vertices
}