using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour {

	public float CurrentHealth {get ; set ;}
	public float MaxHealth { get  ; set; }
	public GameObject elmetto100;
	public GameObject elmetto50;
	public GameObject morte;
	public GameObject elmetto25;
	public Slider healthbar=null;

	// Use this for initialization
	void Start () {

		morte.gameObject.SetActive (false);
		MaxHealth = 100f;
		CurrentHealth = MaxHealth;
		healthbar.value = MaxHealth;

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "KitMedico")
			Medikit (25);
		if ((other.gameObject.tag == "collEnemy" )||(other.gameObject.tag == "ProiettileEnemy" )) 
		{
			DealDamage (10);
		}

	}

	// Update is called once per frame
	void Update () {
			
		if (CurrentHealth <= 100) {

			elmetto100.gameObject.SetActive (true);
			elmetto50.gameObject.SetActive (false);
			elmetto25.gameObject.SetActive (false);
		
			if (CurrentHealth <= 50) {

				elmetto100.gameObject.SetActive (false);
				elmetto50.gameObject.SetActive (true);
				elmetto25.gameObject.SetActive (false);
			
				if (CurrentHealth <= 25) {

					elmetto100.gameObject.SetActive (false);
					elmetto50.gameObject.SetActive (false);
					elmetto25.gameObject.SetActive (true);
				}
		
			}
		}

			
}

	void DealDamage(float damageValue)
	{
		CurrentHealth = CurrentHealth - damageValue;
		healthbar.value = CurrentHealth;
		if(CurrentHealth <=0)
			Die();
	}

	void Medikit(float cureValue)
	{
		if(CurrentHealth <=100)
		CurrentHealth = CurrentHealth +cureValue;
		healthbar.value = CurrentHealth;
	}



	void Die ()
	{
		SceneManager.LoadScene (0);

	}
}