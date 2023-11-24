using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider expSlider;
    public Player player;
    public float maxExp;
    void Start()
    {
        if (expSlider != null)
        {
            // Đặt giá trị tối đa cho Slider
            expSlider.maxValue = maxExp;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       UpdateExpSlider();
    }


    // Gọi khi player nhận được Exp
    void UpdateExpSlider()
    {
        // Đảm bảo rằng expSlider đã được liên kết trong Inspector
        if (expSlider != null)
        {
            // Gán giá trị exp cho Slider
           
            if(expSlider.value >= maxExp) {
                expSlider.value = 0;
                player.playerExp =0;
            }
            else
            {
                expSlider.value = player.playerExp;
            }
        }
        
    }
}
