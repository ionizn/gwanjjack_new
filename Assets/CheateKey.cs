using UnityEngine;
using System.Collections;

public class CheateKey : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("h"))
		{
			Application.LoadLevel("Ending2");
		}
	}
}
