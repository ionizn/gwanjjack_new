using UnityEngine;
using System.Collections;

public class TitleAnim : MonoBehaviour {

	public GameObject view1;
	public GameObject view2;
	public GameObject view3;

bool isView1 = true;
bool isView2 = false;
bool isView3 = false;


	// Use this for initialization
	void Start () {
		InvokeRepeating("ShowTitle", 0.2f,0.2f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ShowTitle()
	{
		if(isView1)
		{
			//Debug.Log("1");
			view1.SetActive(true);
			view2.SetActive(false);
			view3.SetActive(false);

			isView1 =false;
			isView2 = true;
			isView3 = false;
		}

		else if(isView2)
		{
			//Debug.Log("2");

			view2.SetActive(true);
			view1.SetActive(false);
			view3.SetActive(false);

			isView1 =false;
			isView2 = false;
			isView3 = true;

		}
		else if(isView3)
		{
			view3.SetActive(true);
			view1.SetActive(false);
			view2.SetActive(false);
			isView1 =true;
			isView2 = false;
			isView3 = false;
		}
	}


}
