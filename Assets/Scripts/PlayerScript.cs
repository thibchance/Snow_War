using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour{
    enum SnowBallType
    {
        
        DOUBLESNOWBALL,
        BIGSNOWBALL,
        SNOWWAVE,
        SNOWWHIRL,
        LENGTH

    }
    private SnowBallType snowbaltype;

    [SerializeField] GameObject[] snowballs;

    int snowballs_use = 0;

    [SerializeField] GameObject BulletPosition;

    [SerializeField] float speed;

    [SerializeField] Transform Bulletspawn;

    [SerializeField] float snowballSpeed;

    [SerializeField] float timeToThrow = 2;

    [SerializeField] float lastTimeThrow;

    private Rigidbody2D body;
    private float timeLeft = 10f;
    private int ScoreCoins = 100;
    private GameManager gameManager;
    private PlayerHealth playerHealth;
    private bool startTimer = false;

    
    [SerializeField] private float timeSlide;

    [SerializeField] private float timeSlidemax = 3;

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


        Slide();
      
        if(startTimer)
        {
            Debug.Log("ca sort");
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                Debug.Log("ca marche");
                startTimer = false;
                timeLeft = 20f;
            }
        }
        else
        {
            Debug.Log("ca reste ici");
            GameObject NormalSnowBall = snowballs[0];
            NormalSnowBall.GetComponent<Rigidbody2D>().velocity = new Vector2(-4.0f, -2.0f);
            snowballs_use = 0;
            snowballSpeed = 6.0f;
            timeToThrow = 2;
        }
        
    }
    public void Attack()
    {
        if (Time.realtimeSinceStartup - lastTimeThrow > timeToThrow)
        {
            GameObject Snowball = Instantiate(snowballs[snowballs_use], Bulletspawn.position, Bulletspawn.rotation);
            Snowball.GetComponent<Rigidbody2D>().velocity = Bulletspawn.right * snowballSpeed;
            Destroy(Snowball, 5);
            lastTimeThrow = Time.realtimeSinceStartup;
        }
    }
    private void Slide()

    {
        if (timeSlide < timeSlidemax)
        {     
            if (Input.GetKey(KeyCode.Space))
            {
                //animation de gliss
                player.isTrigger = true; 
            }

            if (player.isTrigger == true)
            {
                timeSlide++;
            }
        }
        if (timeSlide== timeSlidemax)
        {
            player.isTrigger = false;
            timeSlide = 0;
        }
        
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
      
        if (collision.gameObject.tag == "Bonus")
        {
            //(int)Random.Range(0, (float)SnowBallType.LENGTH)
            Destroy(collision.gameObject);
            switch(0)
            {
                
                case 0:
                    timeToThrow /= 4;
                    startTimer = true;
                    break;
                case 1: 
                    snowballs_use = 1;
                    startTimer = true;
                    break;
                case 2:
                    //SNOWWAVE
                    GameObject Wave = snowballs[2];
                    Wave.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                    snowballSpeed = 0.0f;
                    snowballs_use = 2;
                    Destroy(Wave, 1);
                    startTimer = true;
                    break; 
                

            }
                
        }
        
        if (collision.gameObject.tag == "SnowballEnemy") 
        {
            // playerHealth.LoseLife();
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
