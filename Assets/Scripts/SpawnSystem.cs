using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnSystem : MonoBehaviour {

    int credits = 200;

    bool startSpawn = true;

    [SerializeField] Transform[] spawns;
    [SerializeField] GameObject boy;
    [SerializeField] GameObject bigBro;
    [SerializeField] GameObject bigSis;
    [SerializeField] GameObject bigBoy;
    [SerializeField] GameObject dog;
    [SerializeField] GameObject cat;
    int creditsBoy = 10;
    int creditsBigBrother = 15;
    int creditsBigSister = 15;
    int creditsBigBoy = 20;
    int creditsDog = 5;
    int creditsCat = 5;
    private GameManager gameManager;
    // Use this for initialization
    void Start ()
    {
        StartCoroutine("RandomSpawn");
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Credits" + credits);

        if (credits <= 0)
        {
            startSpawn = false;
            
        }
  
	}

    IEnumerator RandomSpawn()
    {
        while (startSpawn == true)
        {
            yield return new WaitForSeconds(2);
            RandomEnemy();
        }
    }

    public void RandomEnemy()
    {
        int EnemySpawnchance = Random.Range(0, 101);

        if(EnemySpawnchance <= 30)
        {
            Debug.Log("Boy I Choose you !");
            if (credits < creditsBoy)
            {
                RandomEnemy();
            }
            credits = credits - creditsBoy;
            gameManager.Apparait();
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(boy, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        if (EnemySpawnchance > 30 && EnemySpawnchance <= 45)
        {
            Debug.Log("Big Brother I Choose you !");
            if (credits < creditsBigBrother)
            {
                RandomEnemy();
            }
            credits = credits - creditsBigBrother;
            gameManager.Apparait();
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(bigBro, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        if (EnemySpawnchance > 45 && EnemySpawnchance <= 60)
        {
            Debug.Log("Big Sister I Choose you !");
            if (credits < creditsBigSister)
            {
                RandomEnemy();
            }
            credits = credits - creditsBigSister;
            gameManager.Apparait();
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(bigSis, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        if (EnemySpawnchance > 60 && EnemySpawnchance <= 70)
        {
            Debug.Log("Big Boy I Choose you !");
            if (credits < creditsBigBoy)
            {
                RandomEnemy();
            }
            credits = credits - creditsBigBoy;
            gameManager.Apparait();
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(bigBoy, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        if (EnemySpawnchance > 70 && EnemySpawnchance <= 95)
        {
            Debug.Log("Dog I Choose you !");
            credits = credits - creditsDog;
            gameManager.Apparait();
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(dog, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        if(EnemySpawnchance > 95 && EnemySpawnchance <= 100)
        {
            Debug.Log("Cat I Choose you !");
            credits = credits - creditsCat;
            
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(cat, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        
        
    }
}
