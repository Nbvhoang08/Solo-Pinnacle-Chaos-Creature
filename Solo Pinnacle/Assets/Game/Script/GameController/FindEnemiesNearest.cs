using Mono.Cecil.Cil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemiesNearest : MonoBehaviour
{
   
    public Transform player; 
    public GameObject[] objectsToCheck;
    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player reference is not set!");
            return;
        }

        if (objectsToCheck.Length == 0)
        {
            Debug.LogWarning("No objects to check!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject closestObject = FindClosestEnemy();

        // Xử lý đối tượng gần nhất ở đây (ví dụ: in tên đối tượng)
        if (closestObject != null)
        {
            Debug.Log("Closest Object: " + closestObject.name);
        }
    }

  
    GameObject FindClosestEnemy()
    {
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        // Tìm tất cả các đối tượng có tag là "enemies"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemies");

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                float distance = Vector3.Distance(player.position, enemy.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        return closestEnemy;
    }
}
