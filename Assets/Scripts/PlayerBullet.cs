using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * File name: PlayerBullet.cs
 * Author's Name: Justin Frasca
 * Student Id: 101020604
**/

public class PlayerBullet : MonoBehaviour {

	[SerializeField]
	GameController GameController;
	float speed;


	void Start () {
		speed = 800f;  // speed of bullet
	}

	void Update () {

		Vector2 position = transform.position;
		position = new Vector2 (position.x + speed * Time.deltaTime, position.y); // moving bullets only on the x axis

		transform.position = position;

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1)); 

		if (transform.position.x > max.x)
			{
			
			Destroy(gameObject);  // destry object (bullet) if goes past max x axis 

		
	}
			
}
	public void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Destroyed") {
			Debug.Log ("Bullet Hit\n");	
			Destroy(gameObject);                // destroyed if hits enemy
		
		}
	}



}
