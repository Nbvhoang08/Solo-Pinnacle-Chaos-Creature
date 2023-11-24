using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemies;
    public GameObject player;
    public float SpawnTime;
    float m_SpawnTime;
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_SpawnTime -= Time.deltaTime;
        if (m_SpawnTime <= 0)
        {
            spawnEnemies();
            m_SpawnTime = SpawnTime;
        }
    }
    public void spawnEnemies()
    {
        float randXPos = Random.Range(player.transform.position.x - 12f, player.transform.position.x + 12f);
        float randYPos = Random.Range(player.transform.position.y - 6f, player.transform.position.x + 6f);

        Vector2 spawnPos = new Vector2(randXPos, player.transform.position.y + 6f);
        Vector2 spawnPos1 = new Vector2(randXPos, player.transform.position.y - 6f);
        Vector2 spawnPos2 = new Vector2(player.transform.position.x - 12f, randYPos);
        Vector2 spawnPos3 = new Vector2(player.transform.position.x + 12f, randYPos);
        if (player)
        {
            Instantiate(Enemies, spawnPos, Quaternion.identity);
            Instantiate(Enemies, spawnPos1, Quaternion.identity);
            Instantiate(Enemies, spawnPos2, Quaternion.identity);
            Instantiate(Enemies, spawnPos3, Quaternion.identity);
        }
    }
}
