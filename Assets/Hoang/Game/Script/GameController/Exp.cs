using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    // Start is called before the first frame update
    public float xp;
    private Transform playerTransform;
    GameObject player; 
    public float attractionDistance ;
    public float movementSpeed = 5f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = player.transform;
        if (playerTransform != null)
        {
            // Tính toán vector hướng từ exp đến người chơi
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            // Kiểm tra khoảng cách
            if (directionToPlayer.magnitude <= attractionDistance)
            {
                // Di chuyển exp về phía người chơi
                transform.position = Vector3.Lerp(transform.position, playerTransform.position, movementSpeed * Time.deltaTime);
            }
        }
    }
}
