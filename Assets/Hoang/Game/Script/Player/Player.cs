using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerExp;
    public int _level;
    public int _hp;
    public int _damage;
    public int _speed;
    public Exp exp;
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject ControlSkill;
    void Start()
    {
        GameObject exp = GameObject.FindGameObjectWithTag("exp");
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = playerExp;
        if(_slider.value >= _slider.maxValue) 
        {
            _slider.value = 0;
            playerExp = 0;
            ControlSkill.SetActive(true);
            ControlSkill.GetComponent<ControllerSkillPlayer>().instanSkill();
        }
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
