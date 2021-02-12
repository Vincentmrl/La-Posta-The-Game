using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour {
	public Transform canvas;
	private int inizio=0; 
	private int attivo=1;
	public GameObject iniziamo= null;
	// Use this for initialization
	void Start () {
		

		Time.timeScale = 1;

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (attivo == 1) {
				iniziamo.gameObject.SetActive (false);
				attivo = 0;
			}
			pausa ();
		}
	}

	public void pausa ()
	{
		
			if (canvas.gameObject.activeInHierarchy == false) {

				canvas.gameObject.SetActive (true);
				Time.timeScale = 0;

			} else {
				canvas.gameObject.SetActive (false);

				Time.timeScale = 1;
			}
	
	}

	public void Esci ()
	{
		#if UNITY_STANDALONE
		//Quit the application
		Application.Quit();
		#endif

		//If we are running in the editor
		#if UNITY_EDITOR
		//Stop playing the scene
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
}
