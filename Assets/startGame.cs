using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class startGame : MonoBehaviour
{
    public bool gameIsEnable;

    public playerMovement playerMovement;
    public playerCollision playerCollision;

    public GameObject obstacles;
    public Rigidbody playerBody;

    public Text text;

    void Start()
    {
        gameIsEnable = false;
    }

    string defaultText = "Press any key to start a game.";
    void Update()
    {
        generatingObstacles generatingObstacles = obstacles.GetComponent<generatingObstacles>();
        if (gameIsEnable)
		{
            text.text = string.Empty;

            playerMovement.enabled = true;
            playerCollision.enabled = true;
            generatingObstacles.enabled = true;
		}
        else
		{
            text.text = defaultText;

            playerMovement.enabled = false;
            playerCollision.enabled = false;
            generatingObstacles.enabled = false;
        }

        if (text.text == defaultText && Input.anyKeyDown)
		{
            gameIsEnable = true;
		}
    }
}
