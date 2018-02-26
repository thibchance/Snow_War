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

    

    enum SpriteDirection
    {
        RIGHT,
        LEFT,
        UP,
        DOWN
    }
    private SpriteDirection spriteDirection;
    public bool mouseRight = false;
    public bool mouseLeft = false;
    public bool mouseUp = false;
    public bool mouseDown = false;


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
    private SpriteRenderer spriteRenderer;
    private bool startTimer = false;
    private bool isInvicible = false;
    
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
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //-----------------------------------------
        Vector2 Heading = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float Distance = Heading.magnitude;
        Debug.Log(Heading / Distance);

        if (Heading.x > 0 && Heading.y > 0)
        {
            if (Heading.x > Heading.y)
            {
                GetComponent<SpriteRenderer>().color = Color.blue;
            }
            if (Heading.y > Heading.x)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        if (Heading.x < 0 && Heading.y < 0)
        {
            if (Heading.x < Heading.y)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
            }
            if (Heading.y < Heading.x)
            {
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
        if (Heading.x > 0 && Heading.y < 0)
        {
            if (Heading.x > Heading.y)
            {
                GetComponent<SpriteRenderer>().color = Color.blue;
            }
            if (Heading.y < 0 && Heading.y < Heading.x)
            {
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
        if (Heading.x < 0 && Heading.y > 0)
        {
            if (Heading.x < Heading.y)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
            }
            if (Heading.y > 0 && Heading.y > Heading.x)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }






        //-----------------------------------------

        Attack();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
        body.velocity = movement;
        //bool isgliss = false;

        if(mouseRight==true)
        {
            Debug.Log("BITE");
            GetComponent<SpriteRenderer>().color = Color.blue;
            spriteDirection = SpriteDirection.RIGHT;
        }
        
       
         

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
            snowballSpeed = 8.0f;
            timeToThrow = 1.0f;
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
                isInvicible = true;
                
                speed = speed+2;

                timeSlide++;

            }

        }
        if (timeSlide== timeSlidemax)
        {
            
            isInvicible = false;
            speed = 5;
            timeSlide = 0;

        }
        
        
        
    }

    public void Sprites()
    {
        switch(spriteDirection)
        {
            case SpriteDirection.RIGHT:
                mouseLeft = false;
                mouseDown = false;
                mouseUp = false;
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case SpriteDirection.LEFT:
                mouseRight = false;
                mouseDown = false;
                mouseUp = false;
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case SpriteDirection.UP:
                mouseLeft = false;
                mouseDown = false;
                mouseRight = false;
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case SpriteDirection.DOWN:
                mouseLeft = false;
                mouseRight = false;
                mouseUp = false;
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
        }
    }

    private IEnumerator Flash()
    {
        for (int i = 0; i < 2; i++)
        {

            GetComponent<SpriteRenderer>().color = Color.clear;
            yield return new WaitForSeconds(.1f);
            GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
      
        if (collision.gameObject.tag == "Bonus")
        {
            
            Destroy(collision.gameObject);
            switch((int)Random.Range(0, (float)SnowBallType.LENGTH))
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
                    DestroyImmediate(Wave, true);
                    startTimer = true;
                    break; 
                

            }
                
        }
        
        if (collision.gameObject.tag == "SnowballEnemy") 
        {
            if (!isInvicible)
            {
                playerHealth.LoseLife();
                StartCoroutine(Flash());
            }
            
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Dog")
        {
            if (!isInvicible)
            {
                playerHealth.LoseLife();
                StartCoroutine(Flash());
            }
            
                
        }
       
        if (collision.gameObject.tag == "ScoreCoin")
        {
            gameManager.score = gameManager.score + ScoreCoins;
            Destroy(collision.gameObject);
        }


    }
}
