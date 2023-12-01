using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    // Start is called before the first frame update
    public Text countdownText;
    public float countdownTime = 300f; // Thời gian đếm ngược là 5 phút (300 giây)
    private bool isCountingDown = false;
    public int minutes = 5;
    public int seconds;
    void Start()
    {
        minutes = 5;
        // Bắt đầu đếm ngược khi Scene được khởi tạo (có thể gọi từ một sự kiện khác)
        StartCountdown();
    }

    void Update()
    {
        if (isCountingDown)
        {
            // Giảm thời gian đếm ngược mỗi frame
            countdownTime -= Time.deltaTime;

            // Hiển thị thời gian đếm ngược dưới dạng chuỗi định dạng phút:giây
             minutes = Mathf.FloorToInt(countdownTime / 60f);
            seconds = Mathf.FloorToInt(countdownTime % 60f);

            // Hiển thị thời gian đếm ngược trên giao diện người dùng (UI)
            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Kiểm tra xem thời gian đếm ngược đã hết chưa
            if (countdownTime <= 0f)
            {
                countdownText.text = "00:00";
                // Thực hiện hành động khi thời gian đếm ngược kết thúc, ví dụ: Load một Scene mới, kết thúc trò chơi, vv.
               Quit();
                StopCountdown();
            }
        }
    }

    // Bắt đầu đếm ngược
    public void StartCountdown()
    {
        isCountingDown = true;
    }

    // Dừng đếm ngược
    public void StopCountdown()
    {
        isCountingDown = false;
        // Thực hiện bất kỳ hành động sau khi dừng đếm ngược (nếu cần)
    }
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}

