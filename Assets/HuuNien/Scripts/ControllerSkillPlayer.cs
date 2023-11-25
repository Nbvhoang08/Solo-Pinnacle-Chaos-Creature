using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSkillPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] skills;
    [SerializeField] private GameObject[] trans_Skill;
    private List<int> starSkill;
    private GameObject sk1, sk2, sk3;
    private int skill1, skill2, skill3;
    void Start()
    {
        this.gameObject.SetActive(false);
        starSkill = new List<int>();
        for(int i = 0; i < skills.Length; i++)
        {
            starSkill.Add(0);
        }
    }

    public void instanSkill()
    {
        skill1 = Random.Range(0, skills.Length);
        skill2 = Random.Range(0, skills.Length);
        skill3 = Random.Range(0, skills.Length);
        while(skill1 == skill2) skill2 = Random.Range(0, skills.Length);
        while (skill2 == skill3 || skill3 == skill1) skill3 = Random.Range(0, skills.Length);
        sk1 = Instantiate(skills[skill1], trans_Skill[0].transform.position, Quaternion.identity, trans_Skill[0].transform);
        sk1.transform.Find("Star").gameObject.GetComponent<Text>().text = starSkill[skill1].ToString() + " Star";
        sk2 = Instantiate(skills[skill2], trans_Skill[1].transform.position, Quaternion.identity, trans_Skill[1].transform);
        sk2.transform.Find("Star").gameObject.GetComponent<Text>().text = starSkill[skill2].ToString() + " Star";
        sk3 = Instantiate(skills[skill3], trans_Skill[2].transform.position, Quaternion.identity, trans_Skill[2].transform);
        sk3.transform.Find("Star").gameObject.GetComponent<Text>().text = starSkill[skill3].ToString() + " Star";
        Time.timeScale = 0;
    }
    public void onClickChooseSkill(int i)
    {
        Time.timeScale = 1;
        if (i == 1)
        {
            starSkill[skill1]++;
        }else if(i == 2)
        {
            starSkill[skill2]++;
        }
        else
        {
            starSkill[skill3]++;
        }
        Destroy(sk1);
        Destroy(sk2);
        Destroy(sk3);
        this.gameObject.SetActive(false);
    }
}
