using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * File name: EnemyController.cs
 * Author's Name: Justin Frasca
 * Student Id: 101020604
**/

public class BackgroundController : MonoBehaviour {

	[SerializeField]
	private float speed = 8f;    // background speed

	[SerializeField]
	private float startX;    

	[SerializeField]
	private float endX;

	private Transform BackgroundTransform;
	private Vector2 Backgroundpos;

	void Start () {

		this.BackgroundTransform = gameObject.GetComponent<Transform> ();
	}
	
	void Update () {

		Backgroundpos = BackgroundTransform.position;
		Backgroundpos -= new Vector2(speed,0);

		if (Backgroundpos.x < endX){         // reset if is less than ending x
			resetBackground ();
		}
			BackgroundTransform.position = Backgroundpos; 
	}
	
	private void resetBackground(){

		Backgroundpos = new Vector2 (startX,0);  // moving on the x axis
	}
}
