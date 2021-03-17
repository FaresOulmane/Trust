using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[SerializeField] private float cameraMoveSpeed = 120.0f;
	[SerializeField] private  GameObject cameraFollowObj;
	Vector3 followPOS;
	[SerializeField] private  float clampAngle = 80.0f;
	[SerializeField] private  float inputSensitivity = 150.0f;

	 private  float mouseX;
	 private  float mouseY;
	
	private float rotY = 0.0f;
	private float rotX = 0.0f;

	private CharacterController player;

	private void Awake()
	{
		player = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
	}

	void Start ()
	{
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
		// Cursor.lockState = CursorLockMode.Locked;
		// Cursor.visible = false;
	}
	
	void Update () 
	{

		if (!player.OnEnigme&&player.CanMove && Input.GetMouseButton(0))
		{
			mouseX = Input.GetAxisRaw("Mouse X");
			mouseY = Input.GetAxisRaw ("Mouse Y");
		

			rotY += mouseX * inputSensitivity * Time.deltaTime;
			rotX += mouseY * inputSensitivity * Time.deltaTime;

			rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

			Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0.0f);
			transform.rotation = localRotation;
		}


	}

	void LateUpdate ()
	{
		CameraUpdater ();
	}
	
	void CameraUpdater()
	{
		Transform target = cameraFollowObj.transform;
		float step = cameraMoveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}
}
