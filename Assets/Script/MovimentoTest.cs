using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoTest : MonoBehaviour {

	[SerializeField]
	public float velocita;															// Variabili per il movimento e il salto, categorizzate public perchè essendo pubblica è accessibile
	public float altezzaSalto = 7f;															// direttamente dall'interfaccia di Unity per cambiargli il valore
	public float tempoPassatoSalto = 0f;
	public float ritardoSalto;
	public const float GroundRayLength = 1.1f;
	public bool Su = false;
	public bool Giu = false;
	public bool Sinistra = false;
	public bool Destra = false;
	public float turnSpeed = 500f;

	// Use this for initialization
	void Start () {

		altezzaSalto = 7f;	
	}



	void Update() {

		tempoPassatoSalto += 1 * Time.deltaTime;



		if (Input.GetKeyDown(KeyCode.W))
		{
			Su = true;
		};





		if (Input.GetKeyUp(KeyCode.W))
		{
			Su = false;
		};

	




	}





	void FixedUpdate () {







		if (Su)
		{
			transform.Translate(Vector3.forward * velocita * Time.deltaTime);



		};



		if (Physics.Raycast(transform.position, -Vector3.up, GroundRayLength) && Input.GetKey(KeyCode.Space) && tempoPassatoSalto >= ritardoSalto )
		{

			// ... add force in upwards.
			GetComponent<Rigidbody>().AddForce(Vector3.up* altezzaSalto, ForceMode.Impulse);
			tempoPassatoSalto = 0f;


		}





	}



}
