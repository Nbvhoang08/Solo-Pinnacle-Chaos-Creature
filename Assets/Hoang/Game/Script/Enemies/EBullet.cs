using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Rigidbody2D rb;
    public float speed;
    public float time;
    private void Start()
    {
        Destroy(this.gameObject, time);
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Debug.Log("đm doi");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            Vector3 direction = player.transform.position - transform.position;
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90);
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
