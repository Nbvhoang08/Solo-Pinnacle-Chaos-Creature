using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP;


    private GameObject Bullet;
    public float bulletdamage;
    public GameObject horn;
    public GameObject expPrefab;
    public float duration = 5f;
    public float ticksPerSecond;
    public bool VarZone; // kiểm tra va chạm vs zone
    void Start()
    {
      
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Die();
        }
  
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
    void DealDamage(GameObject enemy, float amount)
    {
        HP -= amount;
    }
    
    IEnumerator DealDamagePersecond(GameObject enemy)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Giảm máu của enemies theo mức sát thương mỗi giây
            float damagePerSecond = bulletdamage / duration;
            DealDamage(this.gameObject, damagePerSecond);

            // Tăng thời gian đã trôi qua
            elapsedTime += 1f; // Gây sát thương mỗi giây

            // Chờ 1 giây trước khi tiếp tục vòng lặp
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator DealDamageOverTime(GameObject enemy)
    {
        float elapsedTime = 0f;

        while (VarZone&& elapsedTime < duration)
        {
            // Gây sát thương mỗi giây
            DealDamage(this.gameObject, bulletdamage);

            // Tăng thời gian đã trôi qua
            elapsedTime += 1f;

            // Chờ 1 giây trước khi tiếp tục vòng lặp
            yield return new WaitForSeconds(1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2d)
    {
        
        if (collision2d.gameObject.CompareTag("Player"))
        {

            /*Destroy(this.gameObject);*/

        }
        

    }
    void getObjectDamage(Collider2D collision)
    {
        // lấy thông tin về damage khi va chạm
        Bullet = collision.gameObject;
        bullet bull = Bullet.GetComponent<bullet>();
        bulletdamage = bull.damage;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            getObjectDamage(collision);
          
            HP -= bulletdamage;
        }
        if (collision.gameObject.CompareTag("bullet") && collision.gameObject.layer ==7 )
        {
            getObjectDamage(collision);
           
            StartCoroutine(DealDamagePersecond(this.gameObject));
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullet") && collision.gameObject.layer == 8){
            VarZone= true;
            getObjectDamage(collision);
           
            StartCoroutine(DealDamageOverTime(this.gameObject));
        }
        else if (collision.gameObject.CompareTag("bullet") && collision.gameObject.layer == 10)
        {
            VarZone = true;
            getObjectDamage(collision);

            StartCoroutine(DealDamageOverTime(this.gameObject));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
          
            rb.velocity = Vector2.zero;
        }
        if (collision.CompareTag("Player"))
        {
            VarZone = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
           
            rb.velocity = Vector2.zero;
        }
    }
}
