using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
	public Rigidbody playerBody;
	public Camera playerCamera;
	public GameObject obstacles;

	public startGame startGame;

	void Update()
	{
		if (playerBody.transform.position.x < -11 || playerBody.transform.position.x > 11)
		{
			GameOver();
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "obstacle")
		{
			GameOver();
		}
	}

	public void GameOver()
	{
		playerBody.velocity = Vector3.zero;
		playerBody.transform.position = new Vector3(0, 1f, 0);
		playerBody.transform.rotation = Quaternion.identity;

		playerCamera.transform.position = new Vector3
		   (playerBody.transform.position.x, playerBody.transform.position.y + 1f, playerBody.transform.position.z - 5f);

		obstacles.transform.position = Vector3.zero;

		foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("cactus"))
		{
			if (obstacle.name != "Cactus1" && obstacle.name != "Cactus2" && obstacle != null)
			{
				GameObject.Destroy(obstacle);
			}
		}

		startGame.gameIsEnable = false;
	}
}
