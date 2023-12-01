using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;


public class Uzumaki : MonoBehaviour
{
    // Start is called before the first frame update
  

    public float gravitationalForce = 10f;
    public float pullRadius;
    [SerializeField] LayerMask enemyLayer; // Layer chứa các enemies
    private bool isAttracting = true;
    public float timeleft;
    public float countdown;

    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAttracting)
            return;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, pullRadius,enemyLayer);
        if (enemies.Length > 0)
        {
            Debug.Log("enemies Length"+ enemies.Length);
        }
        foreach (Collider2D enemyCollider in enemies)
        {
            Rigidbody2D rbToAttract = enemyCollider.GetComponent<Rigidbody2D>();

            if (rbToAttract != null)
            {
                Debug.Log("hut");
                Vector3 direction = transform.position - enemyCollider.transform.position;
                float distance = direction.magnitude;

                // Áp dụng lực hút
                float forceMagnitude = gravitationalForce / Mathf.Pow(distance, 2);
                Vector3 force = direction.normalized * forceMagnitude;
                rbToAttract.AddForce(direction.normalized* gravitationalForce, ForceMode2D.Impulse);
            }
        }
        StartCoroutine(StartCountdown());
    }
    public void StopAttracting()
    {
        isAttracting = false;

        // Loại bỏ lực hút trên tất cả các vật thể "enemies"
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, pullRadius, enemyLayer);

        foreach (Collider2D enemyCollider in enemies)
        {
            Rigidbody2D rbToAttract = enemyCollider.GetComponent<Rigidbody2D>();

            if (rbToAttract != null)
            {
                // Loại bỏ lực hút
                rbToAttract.velocity = Vector3.zero;
            }
        }
    }
    IEnumerator StartCountdown()
    {
        float timeLeft =  countdown ;

        while (timeLeft > 0f)
        {
            
            yield return new WaitForSeconds(1f);
            timeLeft -= 1f;
        }
        StopAttracting();
     }


}

