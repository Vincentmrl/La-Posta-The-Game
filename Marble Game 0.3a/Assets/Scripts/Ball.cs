using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	[SerializeField] private float movePower = 5; // The force added to the ball to move it.
	[SerializeField] private float MovePower2 = 5;
    [SerializeField] private bool useTorque = true;             // Whether or not to use torque to move the ball.
    [SerializeField] private float maxAngularVelocity = 25;     // The maximum velocity the ball can rotate at.
    [SerializeField] private float jumpPower = 2;               // The force added to the ball when it jumps.

	
    
    private const float GroundRayLength = 0.5f;                   // The length of the ray to check if the ball is grounded.
	public GUIText Text1;
	public GUIText Text2;
	public GUIText Text3;
	public GUIText Text4;
	public GUIText Text5;
	public GUIText countText;
	public GUIText winText;
	public GameObject[] PUCount;
	static int PUNumber;
	private int count;


    void Start()
	{
        // Set the maximum angular velocity.
		GetComponent<Rigidbody>().maxAngularVelocity = maxAngularVelocity;
		Debug.Log("Game Initialized");
		Debug.Log("Player Controls & Counter Initializd");
		winText.text = "";
		Text1.text = "";
		Text2.text = "";
		Text3.text = "";
		Text4.text = "";
		Text5.text = "";
		count = 0;
		SetCountText();
		PUCount = GameObject.FindGameObjectsWithTag("PickUp");
		
		PUNumber = PUCount.Length;
	}


	public void Move (Vector3 moveDirection, bool jump)
    {


        // If using torque to rotate the ball...
		if (useTorque) 
		{
            // ... add torque around the axis defined by the move direction.
			GetComponent<Rigidbody>().AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * movePower);


            // Add force to move while in air
			GetComponent<Rigidbody>().AddForce( moveDirection * MovePower2);
		}

        // If on the ground and jump is pressed...
        if (Physics.Raycast(transform.position, -Vector3.up, GroundRayLength) && jump)
        {
            // ... add force in upwards.
            GetComponent<Rigidbody>().AddForce(Vector3.up*jumpPower, ForceMode.Impulse);
        }
	}



	
	// Update is called once per frame
	void Update () {

		PUCount = GameObject.FindGameObjectsWithTag("PickUp");
		if(PUCount.Length == 0)
		{
			winText.text = "You got all the coins, head for the finish!";
			
		}
		Debug.Log(Input.GetAxisRaw("Horizontal"));

		countText.text = "Score: " + count.ToString() + "/" + PUNumber;

	}
	
	
	
	//On Trigger Enter
	IEnumerator OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
			
			
		}

		if(other.gameObject.tag == "Start Pickup")
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			count = count -1;
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
				yield return new WaitForSeconds(5);
				winText.text = "";
			}
			
		}

		//Here Starts GUI Triggers

		if(other.gameObject.tag == "TTrigger1")
			{
				Text1.text = "Trigger 1 is working properly";
			Text2.text = "";
			Text3.text = "";
			Text4.text = "";
			Text5.text = "";
			Debug.Log("Trigger1Activated");
			yield return new WaitForSeconds(5);
				Text1.text = "";
			Debug.Log("Trigger1Deactivated");
			}
		if(other.gameObject.tag == "TTrigger2")
		{
			Text2.text = "Trigger 2 is working properly";
			Text1.text = "";
			Text3.text = "";
			Text4.text = "";
			Text5.text = "";
			Debug.Log("Trigger2Activated");
			yield return new WaitForSeconds(5);
			Text2.text = "";
			Debug.Log("Trigger2Deactivated");
		}
		if(other.gameObject.tag == "TTrigger3")
		{
			Text3.text = "Trigger 3 is working properly";
			Text1.text = "";
			Text2.text = "";
			Text4.text = "";
			Text5.text = "";
			Debug.Log("Trigger3Activated");
			yield return new WaitForSeconds(5);
			Text3.text = "";
			Debug.Log("Trigger3Deactivated");
		}
		if(other.gameObject.tag == "TTrigger4")
		{
			Text4.text = "Trigger 4 is working properly";
			Text1.text = "";
			Text2.text = "";
			Text3.text = "";
			Text5.text = "";
			Debug.Log("Trigger4Activated");
			yield return new WaitForSeconds(5);
			Text4.text = "";
			Debug.Log("Trigger4Deactivated");
		}
		if(other.gameObject.tag == "TTrigger5")
		{
			Text5.text = "Trigger 5 is working properly";
			Text1.text = "";
			Text2.text = "";
			Text3.text = "";
			Text4.text = "";
			Debug.Log("Trigger5Activated");
			yield return new WaitForSeconds(5);
			Text5.text = "";
			Debug.Log("Trigger5Deactivated");
		}
		
	}
	
	
	// Set Count Text: Shows number of coins left to collect
	
	void SetCountText()
	{
		countText.text = "Score: " + count.ToString() + "/" + PUNumber;
		
	}












}
