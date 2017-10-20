using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * File name: EnemyController.cs
 * Author's Name: Justin Frasca
 * Student Id: 101020604
**/

public class EnemyController: MonoBehaviour {

	[SerializeField]
	private float MinYSpeed = -2f;     // up/down speed of the Enemy

	[SerializeField]
	private float MaxYSpeed = 2f;         

	[SerializeField]
	private float MinXSpeed = 11f;     // left/right speed of the Enemy 

	[SerializeField]
	private float MaxXSpeed = 22f;

	[SerializeField]
	GameController GameController;

    private Transform EnemyTransform;
	private Vector2 EnemyCurrentspeed;
	private Vector2 EnemyCurrentPosition;

	   // background music


	void Start () 
	{
		EnemyTransform = gameObject.GetComponent<Transform> ();  // randomize start position 
		Reset();        //reset the position of the Enemy
	}


	void Update () 
	{
		EnemyCurrentPosition = EnemyTransform.position;
		EnemyCurrentPosition -= EnemyCurrentspeed;
		EnemyTransform.position = EnemyCurrentPosition;

		if (EnemyCurrentPosition.x <= -934) {
			Reset ();
		} 





	}

	public void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Bullet") {           // destroy after hits collision
			Reset ();
			GameController.Score += 10;
		} else if (coll.gameObject.tag == "Player") {    // destroy after hits collision
			GameController.Life -= 1;
				Reset ();;
			

		} else if (coll.gameObject.tag == "MainCamera") {  // destroy after hits collision 
			GameController.Life -= 1;
		
	}
	}

	private void Reset()   // gives enemy random positon after destroyed

	{
		float XSpeed = Random.Range(MinXSpeed, MaxXSpeed);
		float YSpeed = Random.Range (MinYSpeed, MaxYSpeed);

		EnemyCurrentspeed = new Vector2 (XSpeed, 0);   //random speed on the x axes
		float XBounds = Random.Range (633, 964);      //randomize position
		float YBounds = Random.Range (-541, 483);     //randomize position
		EnemyTransform.position = new Vector2 (XBounds, YBounds);

	}


}