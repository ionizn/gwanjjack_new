using UnityEngine;
using System.Collections;
using PlatformerPro;
public class OpeningSequence : MonoBehaviour {

	public GameObject coffin_pre;
	public GameObject coffin;
	public GameObject player;
	public GameObject kitty;
	public GameObject arrow;
	public GameObject arrow2;

	public GameObject mummy;


	// Use this for initialization
	void Start () {
		StartCoroutine("GameStart");
		
		//player.GetComponent<GroundMovement>()as.Speed(0);
		iTween.MoveTo(kitty, iTween.Hash("path",iTweenPath.GetPath("kittypath"),"time",4f));

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public IEnumerator GameStart()
    {
  		yield return new WaitForSeconds(0.5f);

		coffin.SetActive(true);
		coffin_pre.SetActive(false);
  		yield return new WaitForSeconds(0.5f);
		player.SetActive(true);
		kitty.SetActive(false);	
		//mummy.transform.localScale = new Vector3(1f,1f,;
		mummy.SetActive(true);	

  		yield return new WaitForSeconds(0.5f);

		arrow.SetActive(true);	
		arrow2.SetActive(true);	

    }


}
