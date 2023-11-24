using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public float timer ;
    public float timebtwFire;
    public float force;
    WEAPON wp;
    void Start()
    {
        timebtwFire = timer;
        wp = FindAnyObjectByType<WEAPON>();    
    }
    private void Update()
    {
        timebtwFire -= Time.deltaTime;
        if (timebtwFire < 0)
        {
            fireBullet();
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

    }
    void fireBullet()
    {
        timebtwFire = timer;

        // Tìm đối tượng kẻ địch gần nhất
        GameObject closestEnemy = wp.FindClosestEnemy();

        if (closestEnemy != null)
        {
            GameObject bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();

            // Tính toán hướng đến đối tượng kẻ địch gần nhất
            Vector2 fireDirection = (closestEnemy.transform.position - transform.position).normalized;

            // Thiết lập góc quay của đạn
            bulletTmp.transform.right = fireDirection;
            float angle = Mathf.Atan2(fireDirection.x, fireDirection.y) * Mathf.Rad2Deg;
            bulletTmp.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            bulletTmp.transform.up = fireDirection;

            // Bắn đạn theo hướng của kẻ địch gần nhất
            rb.AddForce(fireDirection * force, ForceMode2D.Impulse);
        }
    }
  

}
