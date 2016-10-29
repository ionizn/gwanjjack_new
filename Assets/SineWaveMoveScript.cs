using UnityEngine;
using System.Collections;

public class SineWaveMoveScript : MonoBehaviour {
 
     public float speed = 10.0f;
     public float amplitude = 1.0f;
     public float frequency = 0.0f;
     public bool isRight = true;
 
     private float previousOffset = 0.0f;
     private float refAngle = 0.0f;
	 
     void Start() {
     }
     // Update is called once per frame
     void Update () {
         // The base idea: use a reference angle that is increased according to frequency, and use its sine value to calculate the motion on the y axis.
 
         // we update the reference angle according to deltaTime and the frequency
         refAngle += 360*Time.deltaTime*frequency;
         // we make sure the angle is never > 360
         refAngle = Mathf.Repeat(refAngle, 360);
 
         // we calculate the new offset of the gameobject on the y axis
         float yOffset = (Mathf.Sin(refAngle*Mathf.Deg2Rad) * amplitude);
 
         // we move the gameObject on the axis 
         transform.Translate(Vector3.up*(yOffset-previousOffset));
         previousOffset = yOffset;
 
		 if(isRight)
         	// we use the "right" axis to move the gameobject on the x axis
         	transform.Translate (Vector3.right*speed*Time.deltaTime);
		 else
         	// we use the "right" axis to move the gameobject on the x axis
         	transform.Translate (Vector3.left*speed*Time.deltaTime);

     }
 
 }

