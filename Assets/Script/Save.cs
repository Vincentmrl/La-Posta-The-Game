using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Save : MonoBehaviour {

	public GameObject[] ContatoreLivello;
	static int LivelloRaggiunto;

	public void SavePosition ()

	{
		
		PlayerPrefs.SetInt ("LivelloRaggiunto", LivelloRaggiunto);
		Debug.Log (LivelloRaggiunto);
	}

	public void LoadPosition()
	{
		
		int livello = PlayerPrefs.GetInt ("LivelloRaggiunto");
		
		Debug.Log("Il livello è " + livello);
		SceneManager.LoadScene (livello);

	}
	// Use this for initialization
	void Start () {

		ContatoreLivello = GameObject.FindGameObjectsWithTag("Livello");

		LivelloRaggiunto = ContatoreLivello.Length;

	}
	public void Menu ()
	{

		SceneManager.LoadScene (0);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


	