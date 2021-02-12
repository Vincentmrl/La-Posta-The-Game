using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	
	public GUIText countText;
	public GUIText winText;
	public GameObject[] PUCount;
	static int PUNumber;
	private int count;






	//Start

	void Start () {
		Debug.Log("Game Initialized");
		Debug.Log("Player Controls & Counter Initializd");
		count = 0;
		SetCountText();
		winText.text = "";
		PUCount = GameObject.FindGameObjectsWithTag("PickUp");

		PUNumber = PUCount.Length;

	}
	

	// Update is called once per frame
	void Update () {

		if(PUCount.Length == 0)
		{
			winText.text = "You got all the coins, head for the finish!";

		}
	}
	


	//On Trigger Enter
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();

			
		}
		if (other.gameObject.tag == "Bounds")
			
		{

			Application.LoadLevel (Application.loadedLevelName);

		}
		if (other.gameObject.tag == "END")
			
		{
			
			if (PUCount.Length == 0)
			{
				Application.LoadLevel(Application.loadedLevel + 1);
				Debug.Log("Level Complete");
			}
			else
			{
				winText.text = "You haven't collected all the coins yet!";
			}
			
		}
	
	}


	// Set Count Text: Shows number of coins left to collect

	void SetCountText(){

		countText.text = "Score: " + count.ToString() + "/" + PUNumber;
	
	}

	
}

