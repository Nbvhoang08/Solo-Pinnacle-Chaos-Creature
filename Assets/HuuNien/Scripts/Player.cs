using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 500;
    [SerializeField] private Slider slider_EXP;
    [SerializeField] private Text txt_level;
    [SerializeField] private GameObject ChooseSkill;
    private int level;
    private float horizontal, vertical;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        level = 1;
        slider_EXP.maxValue = 10;
    }
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if(Mathf.Abs(horizontal) > 0.1f)
        {
            rb.velocity = new Vector2 (horizontal * speed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
        if (Mathf.Abs(vertical) > 0.1f)
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed * Time.fixedDeltaTime);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        quanLyLevel();
    }

    private void quanLyLevel()
    {
        if(slider_EXP.value >= slider_EXP.maxValue)
        {
            ChooseSkill.SetActive(true);
            ChooseSkill.GetComponent<ControllerSkillPlayer>().instanSkill();
            level++;
            txt_level.text = "LV" + level;
            slider_EXP.value = 0;
            slider_EXP.maxValue *= 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "exp")
        {
            slider_EXP.value+=2;
            Destroy(collision.gameObject);
        }
    }
}
