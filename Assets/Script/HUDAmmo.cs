using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDAmmo : MonoBehaviour {
	Text text;
	string ricaricat;
	SparoTest colpi1;
	SparoTest colpi2;
	SparoTest caricatore1;
	SparoTest caricatore2;
	SparoTest arma;
	SparoTest munizioni;
	SparoTest munizioni1;
	public GameObject storicaricando;
	private bool ricarica = false;
	public float timer;
	public float temporicarica=2;
	public float tempo = 1;
	public float Ricarica=0;
	private float tempoPassatoUltimaRicarica;
	// Use this for initialization

	void Awake ()
	{
		text = GetComponent <Text> ();
	}
		

	void Start () {
		ricaricat = "Ricarica...";
		tempoPassatoUltimaRicarica = temporicarica;
		munizioni = GameObject.FindWithTag ("Player").GetComponent<SparoTest> ();
		munizioni1= GameObject.FindWithTag ("Player").GetComponent<SparoTest> ();
		colpi1 = GameObject.FindWithTag ("Player").GetComponent<SparoTest> ();
		colpi2 = GameObject.FindWithTag ("Player").GetComponent<SparoTest> ();
		caricatore1 =  GameObject.FindWithTag ("Player").GetComponent<SparoTest> ();
		caricatore2 =  GameObject.FindWithTag ("Player").GetComponent<SparoTest> ();
		arma =  GameObject.FindWithTag ("Player").GetComponent<SparoTest> ();

		if (arma.arma == 1 && ricarica== true)
		{
			
			text.text = colpi1.colpi1 + " / " + caricatore1.caricatore1;
		
		}



		
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.R) || timer >= temporicarica && (munizioni.munizioni[1] >= 0))
		{
			
			text.text =  ricaricat ;
			ricarica1 ();
			storicaricando.gameObject.SetActive (true);

		}


		if (ricarica) {
			timer +=Time.deltaTime;
			if (timer >= temporicarica) {
				timer = 0;
				ricarica = false;
			}
		}

		if(Input.GetKey(KeyCode.Z) || tempo >= 1)
		{

			if (arma.arma == 1 && ricarica ==false)
			{
				
				if(munizioni1.munizioni[0]==0) text.text =  ricaricat ;
				else text.text = colpi1.colpi1 + " / " + caricatore1.caricatore1;
				storicaricando.gameObject.SetActive (false);

			}

		}
	}


	void ricarica1 ()
	{
		
			ricarica = true;
			if (timer >= temporicarica) {
				timer = 0;
			text.text =  ricaricat ;
				tempoPassatoUltimaRicarica = 0f;
				ricarica = false;
			}
		}

}
