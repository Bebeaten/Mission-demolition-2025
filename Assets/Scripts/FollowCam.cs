﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

	static public GameObject POI;
	[Header("Set Dynamically")]
	public float easing = 0.05f;
	
	[Header ("Set Dynamically")]
	public float camZ;
	
	void Awake() {
		camZ = this.transform.position.z;
	}
	
	void FixedUpdate() {
		Vector3 destination;
		
		if (POI == null) {
			destination = Vector3.zero;
		}
		else
		{
			destination = POI.transform.position;
			if (POI.tag == "Projectile") {
				if (POI.GetComponent<Rigidbody>().IsSleeping()) {
					POI = null;
					return;
				}
			}
		}
		
		//destination.x = Mathf.Max(minXY.x, destination.x);
		
		//Vector3 destination = POI.transform.position;
		destination = Vector3.Lerp(transform.position, destination, easing);
		destination.z = camZ;
		transform.position = destination;
	}
	
}
