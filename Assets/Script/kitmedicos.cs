﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitmedicos : MonoBehaviour {
	public GameObject kitmedico;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{

			Destroy (kitmedico);

		}

	}
}