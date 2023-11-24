using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP;
    public float damage;
    public bullet bullet;
    public GameObject expPrefab;
    void Start()
    {
        GameObject bullet = GameObject.FindGameObjectWithTag("bullet");

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    

    // Gọi khi enemy bị tiêu diệt
    public void Die()
    {
        // Spawn Exp
        SpawnExp();

        // Hủy đối tượng enemy
        Destroy(gameObject);
    }

    void SpawnExp()
    {
        // Kiểm tra xem có Prefab được gán không
        if (expPrefab != null)
        {
            // Spawn Exp tại vị trí của enemy
            Instantiate(expPrefab, transform.position, Quaternion.identity);
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision2d)
    {
        
        if (collision2d.gameObject.CompareTag("Player"))
        {

            Destroy(this.gameObject);

        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {

            HP -= bullet.damage;
           
            if (HP <= 0)
            {
               Die();
            }
        }
    }
}
