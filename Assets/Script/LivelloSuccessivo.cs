using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivelloSuccessivo : MonoBehaviour {

	public GameObject[] ContatoreLivello;
	int Livello;

	// Use this for initialization
	void Start () {

		ContatoreLivello = GameObject.FindGameObjectsWithTag("Livello");
		Livello = ContatoreLivello.Length;
	}

	// Update is called once per frame

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			SceneManager.LoadScene (Livello+1);
		}

	}


}
