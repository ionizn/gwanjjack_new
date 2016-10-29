using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{

	[SerializeField]
     public float range = 5.0f;
 
     private Transform t;
     public Transform player;
 
     private void Awake()
     {
         t = this.transform;
		 InvokeRepeating( "CheckDistance", 1f, 1f);
		 gameObject.SetActive(false);
	 }
 
     public void CheckDistance()
     {
         if(player)
		 {
			float  dist = Vector3.Distance(transform.position, player.position);
			if(dist <= range)
			{
				Debug.Log("Dist : "+ dist);
				 gameObject.SetActive(true);
				CancelInvoke("CheckDistance");
			}
		 }
	 }

	private void OnDrawGizmos(){
#if UNITY_EDITOR		
		UnityEditor.Handles.color = Color.yellow;
		UnityEditor.Handles.DrawWireDisc(this.transform.position ,Vector3.back, range);
#endif
	}



}
