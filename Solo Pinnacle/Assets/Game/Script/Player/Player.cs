using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerExp ;
    public Exp exp ;
    void Start()
    {
        GameObject exp = GameObject.FindGameObjectWithTag("exp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("exp"))
        {
            GainExp(exp.xp);
            Destroy(collision.gameObject);
        }
    }
    public void GainExp(float expAmount)
    {
        playerExp += expAmount;
        Debug.Log("Player Exp: " + playerExp);
    }
}
