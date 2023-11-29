using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject[] Enemies;
    private GameObject enemies;
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
    GameObject GetRandomEnemies()
    {
        int randomIndex = Random.Range(0, Enemies.Length);
        GameObject randomEnemy = Enemies[randomIndex];
        return randomEnemy;
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
            enemies =GetRandomEnemies();
            Instantiate(enemies, spawnPos, Quaternion.identity);
            Instantiate(enemies, spawnPos1, Quaternion.identity);
            Instantiate(enemies, spawnPos2, Quaternion.identity);
            Instantiate(enemies, spawnPos3, Quaternion.identity);
        }
    }
}
