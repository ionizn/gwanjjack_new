using UnityEngine;
using System.Collections;

public class CheateKey : MonoBehaviour {

    public GameObject character;
    public GameObject place1;
    public GameObject place2;
    public GameObject place3;
    public GameObject place4;
    public GameObject place5;
    public GameObject place6;
    public GameObject place7;
    public GameObject place8;
    public GameObject place9;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("h"))
		{
			Application.LoadLevel("Ending2");
		}

        if (Input.GetKey("1"))
        {
            character.transform.position = place1.transform.position;
        }
        if (Input.GetKey("2"))
        {
            character.transform.position = place2.transform.position;
        }
        if (Input.GetKey("3"))
        {
            character.transform.position = place3.transform.position;
        }
        if (Input.GetKey("4"))
        {
            character.transform.position = place4.transform.position;
        }
        if (Input.GetKey("5"))
        {
            character.transform.position = place5.transform.position;
        }
        if (Input.GetKey("6"))
        {
            character.transform.position = place6.transform.position;
        }
        if (Input.GetKey("7"))
        {
            character.transform.position = place7.transform.position;
        }
        if (Input.GetKey("8"))
        {
            character.transform.position = place8.transform.position;
        }
        if (Input.GetKey("9"))
        {
            character.transform.position = place9.transform.position;
        }

    }
}
