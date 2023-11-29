using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;
using UnityEngine;

public class VoidSphere : MonoBehaviour
{
    // Start is called before the first frame update

   
    private GameObject player;

    public int maxObject;
    public float randX;
    public float randY;
    public float lerpSpeed = 2f; // Tốc độ lướt
    public float interval = 2f; // Khoảng thời gian giữa mỗi lần lướt
    public float standStillTime = 2f; // Thời gian đứng yên sau khi đến vị trí mới
    private Vector2 randomPosition;
    private bool isLerping = false; // Biến kiểm soát quá trình lướt
    private float lerpTimer = 0f; // Biến thời gian lướt
    private float standStillTimer = 0f;
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.Log("haha");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLerping)
        {
            // Lướt tới vị trí ngẫu nhiên xung quanh người chơi
            transform.position = Vector2.Lerp(transform.position, randomPosition, lerpSpeed * Time.deltaTime);

            // Cập nhật biến thời gian lướt
            lerpTimer += Time.deltaTime;

            // Nếu đã đến vị trí mới, đặt lại các biến và bắt đầu đếm thời gian đứng yên
            if (lerpTimer >= interval)
            {
                isLerping = false;
                lerpTimer = 0f;
            }
        }
        else
        {
            // Nếu không trong quá trình lướt, đếm thời gian đứng yên
            standStillTimer += Time.deltaTime;

            // Nếu đã đủ thời gian đứng yên, bắt đầu quá trình lướt và cập nhật vị trí ngẫu nhiên
            if (standStillTimer >= standStillTime)
            {
                isLerping = true;
                randomPosition = GetRandomPosition();
                Debug.Log("randomPos" + randomPosition);
                standStillTimer = 0;
            }
        }
    }

    
    Vector2 GetRandomPosition()
    {
        
            Vector2 playerPosition = player.transform.position;
            float randomX = UnityEngine.Random.Range(playerPosition.x - randX, playerPosition.x + randX); // Điều chỉnh giới hạn theo nhu cầu
            float randomY = UnityEngine.Random.Range(playerPosition.y - randY, playerPosition.y + randY);

            // Tính toán vị trí ngẫu nhiên dựa trên tọa độ người chơi
    
        return new Vector2(randomX, randomY);
    }

}
