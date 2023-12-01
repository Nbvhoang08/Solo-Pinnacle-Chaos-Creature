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
<<<<<<< Updated upstream
    void Start()
    {
        GameObject bullet = GameObject.FindGameObjectWithTag("bullet");

=======
    public float duration = 5f;
    public float ticksPerSecond;
    public bool VarZone; // kiểm tra va chạm vs zone
    public SpawnEnemies spawnE;

    void Start()
    {
        GameObject SpawnE = GameObject.FindWithTag("GameController");

        if (SpawnE != null)
        {
            // Lấy component GameController từ đối tượng GameController
            spawnE = SpawnE.GetComponent<SpawnEnemies>();

            // Kiểm tra xem có component GameController hay không
            
        }
>>>>>>> Stashed changes
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
        spawnE.CountEnemmies--;
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
