using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;

    private Transform spawn;
    [SerializeField] private Transform snowballSpawn;
    [SerializeField] private GameObject snowballPrefab;
    [SerializeField] private float snowballSpeed;
    [SerializeField] private float timeToThrow = 2;
    [SerializeField] private float lastTimeThrow;

    // Use this for initialization
    void Start ()
    {
        playerTransform = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        snowballSpawn.rotation = Quaternion.LookRotation(Vector3.forward, playerTransform.position - snowballSpawn.position);
    }
    public void Attack()
    {
        if (Time.realtimeSinceStartup - lastTimeThrow > timeToThrow)
        {
            GameObject Snowball = Instantiate(snowballPrefab, snowballSpawn.position, snowballSpawn.rotation);

            Snowball.GetComponent<Rigidbody2D>().velocity = snowballSpawn.up * snowballSpeed;
            Destroy(Snowball, 5);
            lastTimeThrow = Time.realtimeSinceStartup;
        }
    }
}
