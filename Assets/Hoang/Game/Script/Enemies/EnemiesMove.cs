using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D e_rb;
    public float moveSpeed;
    private GameObject player;
    void Start()
    {
        e_rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null) // Kiểm tra xem đã tìm thấy đối tượng người chơi chưa
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            directionToPlayer.Normalize();

            // Di chuyển kẻ thù theo hướng tính toán được
            transform.position += directionToPlayer * moveSpeed * Time.fixedDeltaTime;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    public void followplayer()
    {
        float playerXPos = player.transform.position.x;
        float playerYPos = player.transform.position.y;
        if (true)
        {
            e_rb.velocity = new Vector2(playerXPos, playerYPos) * Time.fixedDeltaTime;
        }
    }
}
