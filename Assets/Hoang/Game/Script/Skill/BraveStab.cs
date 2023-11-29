using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraveStab : MonoBehaviour
{
    // Start is called before the first frame update
    public float TimeStab;
    public float timer;
    public WEAPON wp;
    public GameObject braveStab;


    void Start()
    {
        TimeStab = timer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeStab -= Time.fixedDeltaTime;
        if (TimeStab < 0)
        {
            Stab();
        }
       
        braveStab.transform.position = wp.transform.position;
        
    }
    void Stab()
    {
        TimeStab = timer;
        GameObject closestEnemy = wp.FindClosestEnemy();
        if (closestEnemy != null)
        {
            GameObject stab = Instantiate(braveStab, wp.transform.position, Quaternion.identity);


            // Tính toán hướng đến đối tượng kẻ địch gần nhất
            Vector2 fireDirection = (closestEnemy.transform.position - transform.position).normalized;

            // Thiết lập góc quay của đạn
            stab.transform.right = fireDirection;
            float angle = Mathf.Atan2(fireDirection.x, fireDirection.y) * Mathf.Rad2Deg;
            stab.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            stab.transform.up = fireDirection;
          
           
        }
    }
}
