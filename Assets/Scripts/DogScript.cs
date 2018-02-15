using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DogScript : MonoBehaviour{

    [SerializeField] float movespeed = 1f;

    [SerializeField] GameManager gameManager;

    private Transform playerTransform;
    //Vector2 Destination;
    private PlayerEnergyBar playerEnergy;
    private int health = 1;
    private int deadpoints = 50;
    
    // Use this for initialization
    void Start ()
    {
        playerTransform = FindObjectOfType<PlayerScript>().transform;
        gameManager = FindObjectOfType<GameManager>();
        playerEnergy = FindObjectOfType<PlayerEnergyBar>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, movespeed * Time.deltaTime);

        if (health <= 0)
        {
            Destroy(gameObject);
            playerEnergy.WinEnergy();
            gameManager.score = gameManager.score + deadpoints;
            gameManager.Dieboy();


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SnowballPlayer")
        {
            health = health - 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BigSnowBall")
        {
            health = health - 2;
        }

        if (collision.gameObject.tag == "Wave")
        {
            health = health - 2;
        }
    }
}
