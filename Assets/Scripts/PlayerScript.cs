using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour{
    enum SnowBallType
    {
        
        DOUBLESNOWBALL,
        BIGSNOWBALL,
        SNOWWAVE,
        LENGTH

    }
    private SnowBallType snowbaltype;

    [SerializeField] GameObject bullet;

    [SerializeField] GameObject BulletPosition;

    [SerializeField] float speed;

    [SerializeField] Transform Bulletspawn;

    [SerializeField] float snowballSpeed;

    [SerializeField] float timeToThrow = 2;

    [SerializeField] float lastTimeThrow;

    private Rigidbody2D body;
    private float timeLeft = 20f;
    private int ScoreCoins = 100;
    private GameManager gameManager;
    private PlayerHealth playerHealth;
    private bool startTimer = false;

    
    [SerializeField]
    private float timeGliss;
    [SerializeField]
    private float timeGlissmax = 3;
    Collider2D player;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GetComponent<Collider2D>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        gameManager = FindObjectOfType<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
        body.velocity = movement;
        //bool isgliss = false;


        Gliss();
      
        if(startTimer)
        {
            timeLeft -= Time.deltaTime;



            if (timeLeft < 0)
            {
                timeToThrow = 2;
                startTimer = false;
                timeLeft = 20f;
            }
        }

        
    }
    public void Attack()
    {
        if (Time.realtimeSinceStartup - lastTimeThrow > timeToThrow)
        {
            GameObject Snowball = Instantiate(bullet, Bulletspawn.position, Bulletspawn.rotation);
            Snowball.GetComponent<Rigidbody2D>().velocity = Bulletspawn.right * snowballSpeed;
            Destroy(Snowball, 5);
            lastTimeThrow = Time.realtimeSinceStartup;
        }
    }
    private void Gliss()

    {
        if (timeGliss < timeGlissmax)
        {     
            if (Input.GetKey(KeyCode.Q))
            {
                //animation de gliss
                player.isTrigger = true; 
            }

            if (player.isTrigger == true)
            {
                timeGliss++;
            }
        }
        if (timeGliss == timeGlissmax)
        {
            player.isTrigger = false;
            timeGliss = 0;
        }
        
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BigSnowBall")
        {
           
           // bullet.GetComponent<Collider2D>().enabled = false;
           // voir avec nico pour changer la bullet 
           // startTimer = true ;
            Destroy(collision.gameObject);
            
        }
        
        if (collision.gameObject.tag == "Bonus")
        {
            
            //timeToThrow /= 2;
            //startTimer = true;
            Destroy(collision.gameObject);
            switch((int)Random.Range(0, (float)SnowBallType.LENGTH))
            {
                case 0:
                    //DOUBLESNOWBALL
                    break;
                case 1:
                    //BIGSNOWBALL
                    break;
                case 2:
                    //SNOWWAVE
                    break;
            }
                ;
        }
        
        if (collision.gameObject.tag == "SnowballEnemy") 
        {
            playerHealth.LoseLife();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Dog")
        {
            playerHealth.LoseLife();
        }

        if (collision.gameObject.tag == "ScoreCoin")
        {
            gameManager.score = gameManager.score + ScoreCoins;
            Destroy(collision.gameObject);
        }


    }
}
