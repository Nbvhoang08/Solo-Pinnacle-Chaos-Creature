using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    Rigidbody2D b_rb;
    GameController m_gc;
    public float damage;
    void Start()
    {
<<<<<<< Updated upstream
        Destroy(this.gameObject, time);
=======
        if(this.gameObject.layer != 8 && this.gameObject.layer != 9 && this.gameObject.layer != 10) {
            Destroy(this.gameObject, time);
          
        }

        player = GameObject.FindWithTag("Player");
>>>>>>> Stashed changes
        b_rb = GetComponent<Rigidbody2D>();
        m_gc = FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("enemies"))
        {
           
            Destroy(this.gameObject);
           

        }

    }
}
