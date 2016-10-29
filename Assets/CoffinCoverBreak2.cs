using UnityEngine;
using System.Collections;

public class CoffinCoverBreak2 : MonoBehaviour {

    public bool gameStart = false;
    public GameObject ps;
    Rigidbody rb;
    Vector3 randomVector;

	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        //ps = GetComponent<ParticleSystem>();
        randomVector = new Vector3(Random.Range(-5, 5), Random.Range(0, 5), Random.Range(-5, 5));
        gameStart = true;// 이 부분을 true로 바꿔야 함
    }

    void Update () {
        if (gameStart )
        {
            rb.AddExplosionForce(300f, gameObject.transform.position + randomVector, 100f, 30f);

            if (ps != null)
            {
                Instantiate(ps, transform.position, Quaternion.identity);
            }
            gameStart = false;
            StartCoroutine(Destroy());

        }
	}

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        DestroyImmediate(ps, true);
        Destroy(gameObject);
        yield break;
    }


}