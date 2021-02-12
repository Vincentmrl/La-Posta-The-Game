using UnityEngine;
using System.Collections;

public class telecamera : MonoBehaviour {
	public GameObject player;
	private Vector3 cameraLocation;
	// Use this for initialization
	void Start () {
		cameraLocation = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + cameraLocation;
	}
}