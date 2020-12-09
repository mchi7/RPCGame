using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public Player player;
    public static Vector2 BL;
    public static Vector2 TR;
    public GameObject wave;


    public Alien alien;

    [SerializeField]
    Boss boss;
    int waveCount = 3;
    int wavesLeft = 0;
    float alienSpeed = 2f;
    ObjectPool newObjectPool;
    List<string> alienList = new List<string> { "Alien1", "Alien2", "Alien3" };

    // Initializing the game
    void Start()
    {

        BL = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)); //bottom left
        TR = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); //top right
        newObjectPool = ObjectPool.instance;
        Instantiate(player);
        Boss.OnbossDead += bossHandler;

        wavesLeft = waveCount;
        repeatSpawn();

    }


    void bossHandler()
    {
        alienSpeed += 2;
        waveCount += 2;
        wavesLeft = waveCount;
        repeatSpawn(); //keep respawning aliens/mob

    }

    void spawnAliens()
    {
        if (wavesLeft == 0)
        {
            CancelInvoke();
            Invoke("spawnBoss", 5f);
            return;
        }

        wavesLeft -= 1;


        //GameObject aliens = Instantiate(wave, Vector2.zero, Quaternion.identity, transform);
        GameObject a1;
        int index;
        string randomString;
        float spaceBetween; ;
        System.Random randNum = new System.Random();

        for (int i = 0; i < 5; i++)
        {
            spaceBetween = UnityEngine.Random.Range(0.1f, 0.9f);
            float x = (i + spaceBetween) / 5;
            index = randNum.Next(alienList.Count);
            randomString = alienList[index];
            Vector2 xyPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * x, Screen.height));
            a1 = newObjectPool.PoolSpawn(randomString, xyPos, Quaternion.identity);

            //xyPos = xyPos + Vector2.up * alien.transform.localScale.y;
            //Alien mobWave = Instantiate(alien, xyPos, Quaternion.identity, aliens.transform) as Alien;
            //mobWave.setSpeed(alienSpeed);
        }

    }

    void spawnBoss()
    {
        Vector2 bossPosition = new Vector2(0, TR.y);
        Instantiate(boss, bossPosition, Quaternion.identity, transform);
    }

    void repeatSpawn()
    {
        InvokeRepeating("spawnAliens", 2, 3);
    }
}
