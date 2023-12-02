using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingLand : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeSpawn;
    public float timer;
    public GameObject Land;
    public WEAPON wp;
    void Start()
    {
        timeSpawn = timer;
        if (Land != null)
        {
            Debug.Log("ok");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSpawn -= Time.fixedDeltaTime;
        if (timeSpawn < 0)
        {
            SpawnSkill();
        }
    }
    void SpawnSkill()
    {
        timeSpawn = timer;
        GameObject closestEnemy = wp.FindClosestEnemy();
        Debug.Log(closestEnemy);
        
        if (closestEnemy != null)
        {
            Instantiate(Land, closestEnemy.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("not ok");
        }
    }
}
