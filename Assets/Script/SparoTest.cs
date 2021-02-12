using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SparoTest : MonoBehaviour {
	public int[] munizioni = new int[4];				//ColpoFucile, CaricatoriFucile, ColpoPistola, CaricatorePistola
	public int[] maxMunizioni = new int[2];				//Idem
	private bool ricarica = false ;
	public float timer;
	public  int colpi1;
	public int colpi2;
	public int caricatore1;
	public int caricatore2;
	public float temporicarica;
	public float ritardoProiettile = 10f;
	public float ritardoColtello = 0.1f;
	public float ritardo = 0.1f;
	public float ritardocarcano = 2f;
	public float ritardospar = 0.5f;
	public float tempoPassatoUltimoSparo = 0f;
	public float tempoPassatoUltimaRicarica = 0f;
	public int UltimaRicarica;
	public Transform posProiettile;
	public Transform posColtello;
	public GameObject Carcano;
	public GameObject Carcanor;
	public GameObject Carcanos;
	public GameObject Coltello;
	public GameObject Coltellos;
	public GameObject hudCarcano;
	public GameObject hudColtello;
	public GameObject proiettile = null;
	public GameObject coltello = null;
	public GameObject minimappa;
	public GameObject vittoria;
	public int arma;				// 1 = Fucile, 2 = Pistola, 3 = Coltello
	private int attivo=0;
	private int attivor=0;
	private int attivos=0;


	void Awake ()
	{
		arma = 1;
		UltimaRicarica = 1;
		temporicarica = 2;
		munizioni[0] = 5;
		colpi1 = 5;
		munizioni [1] = 100;
		caricatore1 = 100;
		maxMunizioni [0] = 5;


	}


	// Use this for initialization
	void Start () {
		tempoPassatoUltimaRicarica = temporicarica;
		tempoPassatoUltimoSparo =2;

	}

	// Update is called once per frame
	void Update () {




			
	
		
		if (attivo == 1 && arma == 2 && (tempoPassatoUltimoSparo >= ritardoColtello)) {
			Carcano.gameObject.SetActive (false);
			Coltello.gameObject.SetActive (true);
			Coltellos.gameObject.SetActive (false);
			attivo = 0;
		}
		if (attivor == 1 && arma == 1 && (tempoPassatoUltimoSparo >= ritardocarcano) && colpi1 >0) {
			Carcano.gameObject.SetActive (true);
			Carcanor.gameObject.SetActive (false);
			attivor = 0;
		}
		if (attivos == 1 && arma == 1 && (tempoPassatoUltimoSparo >= ritardospar)) {
			Carcano.gameObject.SetActive (true);
			Carcanos.gameObject.SetActive (false);
			attivos = 0;
		}
		tempoPassatoUltimoSparo += 1 * Time.deltaTime;
		tempoPassatoUltimaRicarica += 1 * Time.deltaTime;

		if(Input.GetKey(KeyCode.Alpha1) && arma != 1){
			arma = 1;
			Carcano.gameObject.SetActive (true);
			Coltello.gameObject.SetActive (false);
			hudCarcano.gameObject.SetActive (true);
			hudColtello.gameObject.SetActive (false);
			minimappa.gameObject.SetActive (false);
			arma = 1;
		}
		if(Input.GetKey(KeyCode.Alpha2) && arma != 2){
			arma = 2;
			Carcano.gameObject.SetActive (false);
			Coltello.gameObject.SetActive (true);
			hudCarcano.gameObject.SetActive (false);
			hudColtello.gameObject.SetActive (true);
			minimappa.gameObject.SetActive (false);
			arma = 2;

		}
		if (Input.GetKey (KeyCode.M)) {
			arma = 2;
			Carcano.gameObject.SetActive (false);
			Coltello.gameObject.SetActive (false);
			hudCarcano.gameObject.SetActive (false);
			hudColtello.gameObject.SetActive (false);
			minimappa.gameObject.SetActive (true);
			arma = 3;

		}
		switch (arma) {

		case 1:



			if(Input.GetKey(KeyCode.Mouse0) && (tempoPassatoUltimoSparo >= 1) && (!ricarica) && (munizioni[1] >= 0))
			{
				tempoPassatoUltimoSparo = 0f;
				if (munizioni [0] > 0) {
					Carcano.gameObject.SetActive (false);
					Carcanos.gameObject.SetActive (true);
					attivos = 1;
					colpi1--;
					munizioni [0]--;
					Sparamento ();
				} else if (caricatore1 > 0)
					ricarica1 ();


			}

			if (ricarica) {
				
				timer +=Time.deltaTime;
					if (timer >= temporicarica) {
					animazioneric ();
						timer = 0;
						ricarica = false;
						caricatore1--;
						munizioni [1]--;
						colpi1 = maxMunizioni [0];
						munizioni [0] = maxMunizioni [0];



				}
			}

			break;

		case 2:
			
			if (Input.GetKey (KeyCode.Mouse0) && (tempoPassatoUltimoSparo >= ritardoProiettile) && (attivo==0)) {
				Carcano.gameObject.SetActive (false);
			
				Coltello.gameObject.SetActive (false);
				Coltellos.gameObject.SetActive (true);
				attivo = 1;
				tempoPassatoUltimoSparo = 0f;
			}
			break;

		}
	}


		



	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "kitmunizioni")
			caricatore1 =100;
		if (other.gameObject.tag == "Vittoria") {
			
			vittoria.gameObject.SetActive (true);
			Time.timeScale = 0;
		}
	}



	



	void Sparamento() {

		GameObject clone = (GameObject)Instantiate (proiettile, posProiettile.position, posProiettile.rotation);
		tempoPassatoUltimoSparo = 0f;
	}



	void ricarica1 ()
	{
		
		if (munizioni[1] > 0) {
			animazioneric ();
			ricarica = true;

				if (timer >= temporicarica) {
					timer = 0;
					caricatore1--;
					munizioni [0] = maxMunizioni [0];
					munizioni [1]--;
					colpi1 = maxMunizioni [0];
					tempoPassatoUltimaRicarica = 0f;
					ricarica = false;


			}
		}
	}
	void animazioneric ()

	{
		if (attivor==0 && caricatore1>0)
		{
			Carcano.gameObject.SetActive (false);
			Carcanor.gameObject.SetActive (true);
			attivor=1;
		}
	}


	void ricarica2()
	{
		if (munizioni[3]  > 0) {
			ricarica = true;
			if (timer >= temporicarica) {
				timer = 0;
				caricatore2--;
				munizioni[2] = maxMunizioni[1];
				munizioni[3]--;
				colpi2=maxMunizioni [1];
				tempoPassatoUltimaRicarica = 0f;
				ricarica = false;
			}
		}
	}




}