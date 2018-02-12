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
    private float moveSpeed = 3;
    [SerializeField] private Transform bossTransform;
    [SerializeField] private Transform[] firstModeWayPoints;
    [SerializeField] private Transform[] secondModeWayPoints;
    private int test;
    private BossState bossState = BossState.FIRSTMODE;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bossFight();
        bodyVelocity = body.velocity.y;
        Debug.Log("VELOCITY" + bodyVelocity);
        transform.position = Vector2.MoveTowards(transform.position, firstModeWayPoints[0].transform.position, moveSpeed * Time.deltaTime);
        if (transform.position == firstModeWayPoints[test].transform.position)
        {
            bossFight();
        }
    }

    public void bossFight()
    {
        switch (bossState)
        {
            case BossState.FIRSTMODE:
                
                if (transform.position == firstModeWayPoints[test].transform.position)
                {
                    Debug.Log("GRRRRRRRRRRRR");
                    test = Random.Range(0, 1);
                    Debug.Log("TEST " + test);
                    transform.position = Vector2.MoveTowards(transform.position, firstModeWayPoints[test].transform.position, moveSpeed * Time.deltaTime);
                }
                break;
            case BossState.SECONDMODE:

                break;
            case BossState.THIRDMODE:

                break;
        }
    }
}