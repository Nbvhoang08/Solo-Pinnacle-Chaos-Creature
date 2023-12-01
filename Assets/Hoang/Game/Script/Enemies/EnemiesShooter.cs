using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesShooter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
   /* public Transform shootPoint;*/
    public float shootTimer;
    public int min = 2;
    public int max = 8;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        shootTimer -= Time.deltaTime;


        if (shootTimer <= 0)
        {


            shoot();
            Resetshootimer();
        }

    }
    void Resetshootimer()
    {
        shootTimer = UnityEngine.Random.Range(min, max);
    }
    void FixedUpdate()
    {

    }
    void shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
<<<<<<< HEAD
        
=======
>>>>>>> main
    }
}
