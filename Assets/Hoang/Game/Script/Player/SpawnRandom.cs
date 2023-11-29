using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public GameObject spawn;
    public int maxObject;
    public float timeSpawn;
    public float timer;
    public bool isSpawning;
    public float count;
    public float randX;
    public float randY;
    void Start()
    {
        timeSpawn = timer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSpawn -= Time.fixedDeltaTime;
        if (timeSpawn < 0 )
        {
            spawnRandom();
        }
    }
    public void spawnRandom()
    {
        timeSpawn = timer;
        float randXPos = Random.Range(player.transform.position.x - randX, player.transform.position.x + randX);
        float randYPos = Random.Range(player.transform.position.y - randY, player.transform.position.y + randY);
        
        Vector2 spawnPos = new Vector2(randXPos, randYPos);
       
        if (player)
        {
            for(int i = 0; i< maxObject; i++)
            {
                Instantiate(spawn, spawnPos, Quaternion.identity);
                count++;
            }
           
           
        }
    }
}
