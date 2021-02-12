using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEnemy : MonoBehaviour {
	[SerializeField]

	float velocità = 30f;
	public float tempo = 10f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * velocità;

		Destroy (this.gameObject,tempo);


	}



	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Enemy") 
		{

			Destroy (this.gameObject);
		}

	}

}
