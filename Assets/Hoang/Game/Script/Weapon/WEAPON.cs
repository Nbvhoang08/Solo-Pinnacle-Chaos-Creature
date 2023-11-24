using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEAPON : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player; // Trung tâm của quỹ đạo tròn (vật thể cha)
    public float radius ; // Bán kính của quỹ đạo tròn
    public float speed = 2.0f; // Tốc độ di chuyển


    void Start()
    {
        
    }

    // Update is called once per frame
  
    void FixedUpdate()
    {
        GameObject closestEnemy = FindClosestEnemy();
       
        /*MoveInCircularPath();*/
        MoveToPositionBetweenPlayerAndEnemy(closestEnemy);
       

        // Gán vị trí mới cho vật thể 
    }
    void MoveInCircularPath()
    {
        // Di chuyển theo quỹ đạo tròn xung quanh người chơi
        float angle = Time.time * speed;
        float x = player.position.x + Mathf.Cos(angle) * radius;
        float z = player.position.z + Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, transform.position.y, z);
    }
    public GameObject FindClosestEnemy()
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
    void MoveToPositionBetweenPlayerAndEnemy(GameObject closestEnemy)
    {
        // Di chuyển tới vị trí giữa người chơi và đối tượng gần nhất
        if (closestEnemy != null)
        {
            Vector3 middlePoint = (player.position + closestEnemy.transform.position) / 2f;

            // Tính toán vị trí mới để giữ khoảng cách cố định từ người chơi
            Vector3 directionToPlayer = (player.position - middlePoint).normalized;

            // Tính toán vị trí mới để giữ khoảng cách cố định từ người chơi
            Vector3 newPosition =player.position- directionToPlayer * radius;

            // Di chuyển vật thể tới vị trí mới
            transform.position = newPosition;

        }
        
    }
}
