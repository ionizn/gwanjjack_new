using UnityEngine;
using System.Collections;

public class StageEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGameStartBtnClicked()
	{
		Application.LoadLevel("Intro");
	}
}
