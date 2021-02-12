using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour {
	
	public Transform target;
	public Transform myTransform;
	private int dentro = 0;
	private int fuori = 0;
	private SphereCollider colldentro;
	public float tempoPassatoUltimoSparo = 0f;
	public Transform posProiettile;
	public float ritardoProiettile = 1f;
	public GameObject proiettile = null;
	// Use this for initialization
	void Start () {
		tempoPassatoUltimoSparo = ritardoProiettile;
		colldentro = GetComponent<SphereCollider> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		tempoPassatoUltimoSparo += 1 * Time.deltaTime;
		if (dentro == 1 ) {
			transform.LookAt (target);
			transform.Translate (Vector3.forward *0 * Time.deltaTime);
			if(tempoPassatoUltimoSparo >= ritardoProiettile)
			Sparamento ();
		}
	}
		
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			colldentro.radius = 25f;
			dentro = 1;
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			colldentro.radius = 15f;
			fuori = 1;
			dentro = 0;
		}

	}

	void Sparamento() {

		GameObject clone = (GameObject)Instantiate (proiettile, posProiettile.position, posProiettile.rotation);
		tempoPassatoUltimoSparo = 0f;
	}



}
