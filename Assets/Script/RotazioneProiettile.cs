using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotazioneProiettile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKey(KeyCode.LeftArrow))										//Sinistra
		{
			  		
			transform.rotation = Quaternion.Euler(0,-90,0); 

		};



		if (Input.GetKey(KeyCode.RightArrow))										//Destra
		{

			transform.rotation = Quaternion.Euler(0,90,0); 

		};



		if (Input.GetKey(KeyCode.UpArrow))											//Sopra
		{

			transform.rotation = Quaternion.Euler(0,0,0); 

		};


		if (Input.GetKey(KeyCode.DownArrow))											//Sotto
		{

			transform.rotation = Quaternion.Euler(0,180,0); 

		};



		if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))			//SopraSinistra
		{

			transform.rotation = Quaternion.Euler(0,315,0); 

		};

		if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))			//SopraDestra
		{

			transform.rotation = Quaternion.Euler(0,45,0); 

		};

		if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))			//SottoSinistra
		{

			transform.rotation = Quaternion.Euler(0,225,0); 

		};

		if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))			//SottoDestra
		{

			transform.rotation = Quaternion.Euler(0,135,0); 

		};







	}
}
