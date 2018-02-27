using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

   public enum CatState
    {
        FOLLOW,
        ATTACK,
        FLEE
    }

    
    
    private bool touchPlayer =  false;
    [SerializeField] Transform target;
    [SerializeField] Transform spawnflee;
    [SerializeField] int moveSpeed = 5;
    private float distance;
    private CatState catState = CatState.FOLLOW;
    private int health = 1;
    private int deadpoints = 500;
    private PlayerEnergyBar playerEnergy;
    [SerializeField] GameManager gameManager;
    Collider2D cat;
    private SpriteRenderer render;
    private Animator CatAnimation;
    // Use this for initialization
    void Start ()
    {
        target = FindObjectOfType<PlayerScript>().transform;
        playerEnergy = FindObjectOfType<PlayerEnergyBar>();
        gameManager = FindObjectOfType<GameManager>();
        cat = GetComponent<Collider2D>();
        CatAnimation = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(catState);

       
        if (health <= 0)
        {
            Destroy(gameObject);
            playerEnergy.WinEnergy();
            gameManager.score = gameManager.score + deadpoints;

        }
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance <= 3)
        {
            catState = CatState.ATTACK;
        }
        if (touchPlayer)
        {
            catState = CatState.FLEE;
           
        }

        switch (catState)
        {
            case CatState.FOLLOW:
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
                CatAnimation.SetFloat("VelocityX", target.transform.position.x);
                break;
            case CatState.ATTACK:
                moveSpeed = 8;
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
                break;
            case CatState.FLEE:
                transform.position = Vector2.MoveTowards(transform.position, spawnflee.transform.position, moveSpeed * Time.deltaTime);
                cat.isTrigger = true;
                //render.flipX = touchPlayer;
                CatAnimation.SetBool("Touch", touchPlayer == true);
                break;
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

        if (collision.gameObject.tag == "Player")
        {
            touchPlayer = true;
        }
    }
}
