using UnityEngine;
using System.Collections;

public class StageStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.anyKeyDown)
		{
			OnGameStartBtnClicked();
		}
	}
	public void OnGameStartBtnClicked()
	{
		Application.LoadLevel("Tutorial");
	}
}
