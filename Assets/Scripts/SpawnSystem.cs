using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnSystem : MonoBehaviour {

    int Credits = 500;

    bool startSpawn = true;

    [SerializeField] Transform[] spawns;
    [SerializeField] GameObject boy;
    [SerializeField] GameObject bigBro;
    [SerializeField] GameObject bigSis;
    [SerializeField] GameObject bigBoy;
    [SerializeField] GameObject dog;
    [SerializeField] GameObject cat;
    int ennemiBoy = 10;
    int ennemibigBrother = 15;
    int ennnemibigBoy = 20;
    int ennemidog = 5;
    private GameManager gameManager;
    // Use this for initialization
    void Start ()
    {
        StartCoroutine("RandomSpawn");
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Credits" + Credits);

        if (Credits <= 0)
        {
            startSpawn = false;
            
        }

      
        
	}

    IEnumerator RandomSpawn()
    {
        while (startSpawn == true)
        {
            yield return new WaitForSeconds(1);
            RandomEnemy();
        }
    }

    public void RandomEnemy()
    {
        int EnemySpawnchance = Random.Range(0, 101);

        if(EnemySpawnchance <= 30)
        {
            Debug.Log("Boy I Choose you !");
            Credits = Credits - ennemiBoy;
            gameManager.Apparait();
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(boy, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        if (EnemySpawnchance > 30 && EnemySpawnchance <= 45)
        {
            Debug.Log("Big Brother I Choose you !");
            Credits = Credits - ennemibigBrother;
            gameManager.Apparait();
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(bigBro, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        if (EnemySpawnchance > 45 && EnemySpawnchance <= 60)
        {
            Debug.Log("Big Sister I Choose you !");
            Credits = Credits - ennemibigBrother;
            gameManager.Apparait();
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(bigSis, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        if (EnemySpawnchance > 60 && EnemySpawnchance <= 70)
        {
            Debug.Log("Big Boy I Choose you !");
            Credits = Credits - ennnemibigBoy;
            gameManager.Apparait();
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(bigBoy, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        if (EnemySpawnchance > 70 && EnemySpawnchance <= 95)
        {
            Debug.Log("Dog I Choose you !");
            Credits = Credits - ennemidog;
            gameManager.Apparait();
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(dog, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        else
        {
            Debug.Log("Cat I Choose you !");
            Credits = Credits - ennemidog;
            
            int spawnIndex = Random.Range(0, spawns.Length);
            Instantiate(cat, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        
        
    }
}
