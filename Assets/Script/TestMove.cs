using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {

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
	public bool Scatto = false;

	// Use this for initialization
	void Start () {
		velocita = 5f;
		altezzaSalto = 7f;	
	}



	void Update() {

		tempoPassatoSalto += 1 * Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.LeftShift))						//Tasti Premuti							
		{
			Scatto = true;	  		
		};

		if (Input.GetKeyDown(KeyCode.A))						//Tasti Premuti							
		{
			Sinistra = true;	  		
		};

		if (Input.GetKeyDown(KeyCode.D))
		{
			Destra = true;
		};

		if (Input.GetKeyDown(KeyCode.W))
		{
			Su = true;
		};

		if (Input.GetKeyDown(KeyCode.S))
		{
			Giu = true;
		};



		if (Input.GetKeyUp(KeyCode.A))							//Tasti lasciati								
		{
			Sinistra = false;	  		
		};

		if (Input.GetKeyUp(KeyCode.D))
		{
			Destra = false;
		};

		if (Input.GetKeyUp(KeyCode.W))
		{
			Su = false;
		};

			if (Input.GetKeyUp(KeyCode.S))
		{
			Giu = false;
		};

		if (Input.GetKeyUp (KeyCode.LeftShift))						//Tasti Premuti							
		{
			velocita = 5f;
			Scatto = false;	  		
		};





	}





	void FixedUpdate () {


		if (Sinistra)										//Se (input.prenditasto(codicetasto.codiceverotasto)) 
		{
			
			transform.position += Vector3.left * velocita * Time.deltaTime;  		// { trasforma.laposizione += Vettore3caselle.direzione * velocità * Tempo; }

		};



		if (Destra)
		{
			 
			transform.position += Vector3.right * velocita * Time.deltaTime;


		};



		if (Su)
		{
			transform.position += Vector3.forward * velocita * Time.deltaTime;



		};



		if (Giu)
		{
			
			transform.position += Vector3.back * velocita * Time.deltaTime;

		};

		if (Scatto)
		{

			velocita = 10f;

		};



		if (Physics.Raycast(transform.position, -Vector3.up, GroundRayLength) && Input.GetKey(KeyCode.Space) && tempoPassatoSalto >= ritardoSalto )
		{

			// ... add force in upwards.
			GetComponent<Rigidbody>().AddForce(Vector3.up* altezzaSalto, ForceMode.Impulse);
			tempoPassatoSalto = 0f;


		}





	}



}
