using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

   

    
    
    private bool touchPlayer =  false;
    [SerializeField] Transform Player;
    [SerializeField] Transform spawnflee;
    [SerializeField] float movespeed = 1f;
    [SerializeField] float speedflee = 1f;
    private int health = 1;
    private int deadpoints = 50;
    private PlayerEnergyBar playerEnergy;
    [SerializeField] GameManager gameManager;
    Collider2D cat;
    // Use this for initialization
    void Start ()
    {
        Player = FindObjectOfType<PlayerScript>().transform;
        playerEnergy = FindObjectOfType<PlayerEnergyBar>();
        gameManager = FindObjectOfType<GameManager>();
        cat = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, movespeed * Time.deltaTime);

        if (touchPlayer)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, spawnflee.transform.position, speedflee * Time.deltaTime);
            cat.isTrigger = true;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            playerEnergy.WinEnergy();
            gameManager.score = gameManager.score + deadpoints;
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touchPlayer = true;
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
