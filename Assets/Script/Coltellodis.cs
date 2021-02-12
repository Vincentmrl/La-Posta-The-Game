using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coltellodis : MonoBehaviour {
	public float tempo = 0001f;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject,tempo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
