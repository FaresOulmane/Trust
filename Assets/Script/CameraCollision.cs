﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
 {

	 [SerializeField] private float minDistance = 1.0f;
	 [SerializeField] private  float maxDistance = 4.0f;
	 [SerializeField] private  float smooth = 10.0f;
	Vector3 dollyDir;
	
	private float distance;
	
	void Awake () 
	{
		dollyDir = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
	}
	
	void Update () 
	{

		Vector3 desiredCameraPos = transform.parent.TransformPoint (dollyDir * maxDistance);
		RaycastHit hit;

		if (Physics.Linecast (transform.parent.position, desiredCameraPos, out hit)) {
			distance = Mathf.Clamp ((hit.distance * 0.87f), minDistance, maxDistance);
				
		} 
		else 
		{
			distance = maxDistance;
		}

		transform.localPosition = Vector3.Lerp (transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
	}
}
