using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * File name: PlayerController.cs
 * Author's Name: Justin Frasca
 * Student Id: 101020604
**/
public class PlayerControl : MonoBehaviour {


	public GameObject PlayerBulletGo;        // stored the bulled in this object 
	public GameObject BulletPosition01;      // made the position of where the bullet comes from

	[SerializeField]
	private float speed = 8f;
	private Vector2 pos;
	[SerializeField]
	private float leftX;
	[SerializeField]
	private float rightX;
	public AudioSource Explode;




	void Start () {
	}

	void Update ()
	{
		Explode = gameObject.GetComponent<AudioSource> ();

		if (Input.GetKeyDown ("space")) {                                   //when the space down key is hit shoot bullet
			GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGo);
			bullet01.transform.position = BulletPosition01.transform.position;
		}
	

		float y = Input.GetAxisRaw ("Vertical");
		float x = Input.GetAxisRaw ("Horizontal");


		// making the direction
		Vector2 direction = new Vector2 (x, y).normalized;   // making the buttons start working

		// Calling function
		Move (direction);    
	}
	void Move (Vector2 direction)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));       
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		max.x = max.x - 0.225f;
		min.x = min.x + 0.225f;

		max.y = max.y - 0.285f;
		min.y = min.y + 0.285f;


		Vector2 pos = transform.position;

		pos += direction * speed * Time.deltaTime;  // speed of movement       

		pos.x = Mathf.Clamp (pos.x, min.x, max.x);        
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		CheckBounds ();    // calling bounds to make sure the player cant go out of bounds 
		transform.position = pos;



	}
	public void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag.Equals ("Destroyed")) {
			Debug.Log ("Collision detected\n");
			if (Explode != null) {
				Explode.Play ();
			}
		}
	}
	private void CheckBounds(){

		if (pos.x < leftX) {
			pos.x = leftX;
		}

		if (pos.x > rightX) {
			pos.x = rightX;
	

}
}
}
