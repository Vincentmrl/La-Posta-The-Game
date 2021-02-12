﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject Player;
	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		Debug.Log("Camera initialized");
		offset = transform.position;;
	}
	

	// Update is called once per frame
	void LateUpdate () {
		transform.position = Player.transform.position + offset;
	}
}
