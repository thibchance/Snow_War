using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnowballSpawnScrpit : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private Transform Spawn;


    [Header("Attack")]
    [SerializeField]
    private GameObject EnemySnowballPrefab;
    [SerializeField] private Transform EnemySnowballSpawn;
    [SerializeField] private float EnemySnowballVelocity = 2;
    [SerializeField] private float timeToThrow = 5;
    private float lastTimeThrow = 0;


    // Use this for initialization
    void Start ()
    {
        target = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Spawn.rotation = Quaternion.LookRotation(Vector3.forward, target.position - Spawn.position);
    }

    public void Attack()
    {
        if (Time.realtimeSinceStartup - lastTimeThrow > timeToThrow)
        {
            GameObject ShitTest = Instantiate(EnemySnowballPrefab, EnemySnowballSpawn.position, EnemySnowballSpawn.rotation);

            ShitTest.GetComponent<Rigidbody2D>().velocity = EnemySnowballSpawn.right * EnemySnowballVelocity;
            Destroy(ShitTest, 5);
            lastTimeThrow = Time.realtimeSinceStartup;
        }
    }
}
