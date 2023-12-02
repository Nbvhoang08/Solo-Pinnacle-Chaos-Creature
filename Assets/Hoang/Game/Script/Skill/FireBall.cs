using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 targetSize = new Vector2(2f, 1f);  // Kích thước cuối cùng bạn muốn đối tượng đạt được
    Rigidbody2D rb;

    public float duration; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemies"))
        {
            rb.velocity = Vector2.zero;
            StartCoroutine(ChangeSizeOverTime());
          
        }  
    }
    IEnumerator ChangeSizeOverTime()
    {
        Vector2 initialSize = transform.localScale;
        float elapsed_time = 0f;

        while (elapsed_time < duration)
        {
            // Tính toán kích thước mới dựa trên thời gian đã trôi qua
            float t = elapsed_time / duration;
            transform.localScale = Vector2.Lerp(initialSize, targetSize, t);

            // Tăng thời gian đã trôi qua
            elapsed_time += Time.fixedDeltaTime;

            // Chờ một frame tiếp theo trước khi tiếp tục vòng lặp
            yield return null;
        }

        // Đảm bảo rằng kích thước đối tượng cuối cùng
        transform.localScale = targetSize;
    }
}
