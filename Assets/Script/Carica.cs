using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Carica : MonoBehaviour {

	int livello =1 ;
	// Use this for initialization
	void Start () {
		
		 livello = PlayerPrefs.GetInt ("LivelloRaggiunto");
	}
	
	// Update is called once per frame
	public void Carica1 ()
	{

		SceneManager.LoadScene (livello);

	}

	public void Menu ()
	{

		SceneManager.LoadScene (0);

	}
}
