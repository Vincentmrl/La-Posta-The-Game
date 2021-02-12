using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour {

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

	// Use this for initialization
	void Start () {

		altezzaSalto = 7f;	
	}



	void Update() {

		tempoPassatoSalto += 1 * Time.deltaTime;


		if (Input.GetKeyDown(KeyCode.LeftArrow))						//Tasti Premuti							
		{
		Sinistra = true;	  		
		};

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Destra = true;
		};

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			Su = true;
		};
			
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			Giu = true;
		};



		if (Input.GetKeyUp(KeyCode.LeftArrow))							//Tasti lasciati								
		{
			Sinistra = false;	  		
		};

		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			Destra = false;
		};

		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			Su = false;
		};

		if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			Giu = false;
		};
			



	}



	

	void FixedUpdate () {


		if (Sinistra)										//Se (input.prenditasto(codicetasto.codiceverotasto)) 
			{
			transform.rotation = Quaternion.Euler(0,-90,0);
			transform.position += Vector3.left * velocita * Time.deltaTime;  		// { trasforma.laposizione += Vettore3caselle.direzione * velocità * Tempo; }

		};
			


		if (Destra)
			{
			transform.rotation = Quaternion.Euler(0,90,0); 
			transform.position += Vector3.right * velocita * Time.deltaTime;


		};

			
			
			if (Su)
			{
			transform.rotation = Quaternion.Euler(0,0,0);
			transform.position += Vector3.forward * velocita * Time.deltaTime;

		

		};

		

		if (Giu)
			{
			transform.rotation = Quaternion.Euler(0,180,0); 
			transform.position += Vector3.back * velocita * Time.deltaTime;

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


		if (Physics.Raycast(transform.position, -Vector3.up, GroundRayLength) && Input.GetKey(KeyCode.Space) && tempoPassatoSalto >= ritardoSalto )
		{

			// ... add force in upwards.
			GetComponent<Rigidbody>().AddForce(Vector3.up* altezzaSalto, ForceMode.Impulse);
			tempoPassatoSalto = 0f;


		}





		}

	

}
