using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour {

    int Credits = 100;

    bool startSpawn = true;

    [SerializeField] Transform[] spawns;
    [SerializeField] GameObject boy;
    [SerializeField] GameObject dog;


    // Use this for initialization
    void Start ()
    {
        StartCoroutine("RandomSpawn");
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Credits" + Credits);
	}

    IEnumerator RandomSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            RandomEnemy();
            if (Credits <= 0)
            {
                yield return null;
            }
        }
    }

    public void RandomEnemy()
    {
        int EnemySpawnchance = Random.Range(0, 101);

        if(EnemySpawnchance<=70)
        {
            Debug.Log("Boy I Choose you !");
            Credits = Credits - 10;
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(boy, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        else
        {
            Debug.Log("Dog I Choose you !");
            Credits = Credits - 5;
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(dog, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
    }

}
