using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using static UnityEditor.Experimental.GraphView.GraphView;
=======
>>>>>>> main

public class EBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Rigidbody2D rb;
    public float speed;
    public float time;
<<<<<<< HEAD
    Vector2 dir;
    void Start()
=======
    private void Start()
>>>>>>> main
    {
        Destroy(this.gameObject, time);
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
        dir = player.transform.position - transform.position;
        Vector3 direction = player.transform.position - transform.position;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
=======

>>>>>>> main
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
<<<<<<< HEAD


            rb.velocity=dir*speed*Time.fixedDeltaTime;
           
=======
            Debug.Log("đm doi");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            Vector3 direction = player.transform.position - transform.position;
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90);
>>>>>>> main
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
