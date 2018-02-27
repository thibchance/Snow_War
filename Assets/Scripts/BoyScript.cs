using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyScript : MonoBehaviour{

    public enum EnemyState
    {
        WALK,
        ATTACK
    }


    [SerializeField] private GameObject snowballSpawn;

    [SerializeField] private GameObject boyAttackZone;

    [SerializeField] private float moveSpeed;

  //[SerializeField] private GameObject target;

    private float distance;
    [SerializeField] private float throwDistance;
    private bool inFieldofview = false;
    private bool IsAttacking = false;
    private float CounterTime = 0.0f;
    private EnemyState enemyState = EnemyState.WALK;

    [SerializeField] private SpawnScript spawnScript;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private DropSystemScript dropSystem;
    

    private PlayerEnergyBar playerEnergy;
    private Transform playerTransform;
    [SerializeField] private int health;
    private int deadpoints = 100;
    private float VelocityXright = 1.0f;
    private float velocityYup = 1.0f;
    private float VelocityX = -1.0f;
    private float velocityY = -1.0f;
    private Animator BoyAnimation;
   
    
    // Use this for initialization
    void Start()
    {
        
        gameManager = FindObjectOfType<GameManager>();
        playerEnergy = FindObjectOfType<PlayerEnergyBar>();
        BoyAnimation = GetComponent<Animator>();
        playerTransform = FindObjectOfType<PlayerScript>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //BoyAnimation.SetFloat("VelocityX", Vector2.MoveTowards(transform.position, playerTransform.transform.position, moveSpeed * Time.deltaTime).x);
        /*BoyAnimation.SetFloat("VelocityY", Vector2.MoveTowards(transform.position, playerTransform.transform.position, moveSpeed * Time.deltaTime).y)*/;
        BoyAnimation.SetFloat("VelocityX", playerTransform.transform.position.x);
        BoyAnimation.SetFloat("VelocityY", playerTransform.transform.position.y);
        move();
        CounterTime += Time.deltaTime;
        if(CounterTime>=0.5f)
        {
            BoyAnimationAttack(false);
            CounterTime = 0.0f;
        }
    }
    public void move()
    {
        distance = Vector2.Distance(transform.position, playerTransform.transform.position);
        //Debug.Log("Distance" + distance);

        if (distance <= throwDistance)
        {
            inFieldofview = true;
            
        }
        else
        {
            inFieldofview = false;
        }
        //Debug.Log("is Attacking " + isAttacking);

        if (inFieldofview)
        {
            enemyState = EnemyState.ATTACK;
        }
        else
        {
            enemyState = EnemyState.WALK;
        }

        switch (enemyState)
        {
            case EnemyState.WALK:
              transform.position = Vector2.MoveTowards(transform.position, playerTransform.transform.position, moveSpeed * Time.deltaTime);
                //BoyAnimation.SetFloat("Speed", moveSpeed);
               
                
                break;
            case EnemyState.ATTACK:
       
                spawnScript.Attack();
                //BoyAnimation.SetTrigger("IsAttack");
                break;
        }
       
            
        if (health <= 0)
        {
            Destroy(gameObject);
            playerEnergy.WinEnergy();
            gameManager.score = gameManager.score + deadpoints;
            dropSystem.calculateLoot();
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

    public void BoyAnimationAttack(bool _action)
    {
        BoyAnimation.SetBool("Isattack", _action);
    }
  
}