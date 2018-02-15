using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    public enum BossState
    {
        FIRSTMODE,
        SECONDMODE,
        THIRDMODE

    }
    private Rigidbody2D body;
    private float bodyVelocity;
    private int health = 30;
    private float moveSpeed = 5;
    private float minimumValue = 0.1f;
    private Transform nextPosition;
    private Transform[] wayPoints;
    [SerializeField] private Transform[] firstModeWayPoints;
    [SerializeField] private Transform[] secondModeWayPoints;
    private int test;
    private BossState bossState = BossState.FIRSTMODE;
    private Transform spawn;

    private Transform target;

    [SerializeField] private Transform[] snowballSpawn;

    [SerializeField] private GameObject snowballPrefab;

    [SerializeField] private float snowballSpeed;

    [SerializeField] private float timeToThrow = 2;

    [SerializeField] private float lastTimeThrow;

    // Use this for initialization
    void Start()
    {
        target = FindObjectOfType<PlayerScript>().transform;
        wayPoints = firstModeWayPoints;
        nextPosition = wayPoints[Random.Range(0, wayPoints.Length)];
    }
    public int GetHEALTH()
    {
        return this.health;
    }
    // Update is called once per frame
    void Update()
    {
        bossFight();
        if (health <= 20)
        {
            bossState = BossState.SECONDMODE;
        }
        if (health <= 10)
        {
            bossState = BossState.THIRDMODE;
        }
    }

    public void bossFight()
    {
        switch (bossState)
        {
            case BossState.FIRSTMODE:
                Move();
                Attack();
                break;
            case BossState.SECONDMODE:
                wayPoints = secondModeWayPoints;
                Move();
                Attack();
                break;
            case BossState.THIRDMODE:
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
                Attack();
                break;
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, nextPosition.position) <= minimumValue)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nextPosition = wayPoints[Random.Range(0, wayPoints.Length)];
    }

    public void Attack()
    {
        if (Time.realtimeSinceStartup - lastTimeThrow > timeToThrow)
        {
            for (int i = 0; i < snowballSpawn.Length; i++)
            {
                GameObject Snowball = Instantiate(snowballPrefab, snowballSpawn[i].position, snowballSpawn[i].rotation);
                Snowball.GetComponent<Rigidbody2D>().velocity = snowballSpawn[i].up * snowballSpeed;
                Destroy(Snowball, 5);
                lastTimeThrow = Time.realtimeSinceStartup;
            }
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