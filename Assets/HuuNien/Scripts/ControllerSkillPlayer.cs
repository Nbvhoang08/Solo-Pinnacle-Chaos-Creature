<<<<<<< HEAD
using System.Collections;
=======
﻿using System.Collections;
>>>>>>> main
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSkillPlayer : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    [SerializeField] private GameObject[] skillRed;
    [SerializeField] private GameObject[] skillBlue;
    [SerializeField] private GameObject[] trans_Skill; // list save position of 3 skill
    private List<Skill> skills; // skillBlue + skillRed
    private int numRedChoose = 0;
    private int numBlueChoose = 0;
    List<int> indexChoose;
    void Start()
    {
        skills = new List<Skill>();
        this.gameObject.SetActive(false);

        for(int i = 0; i< skillRed.Length; i++)
            skills.Add(new Skill(i, skillRed[i].gameObject.name, skillRed[i], 0, "red"));
        for(int i = 0;i< skillBlue.Length; i++)
<<<<<<< Updated upstream
        {
            skills.Add(skillBlue[i]);
        }
        for(int i = 0; i<skillBlue.Length + skillRed.Length; i++)
        {
            starSkills.Add(0);
>>>>>>> main
        }
=======
            skills.Add(new Skill(skillRed.Length + i, skillBlue[i].gameObject.name, skillBlue[i], 0, "blue"));
>>>>>>> Stashed changes
    }

    public void instanSkill()
    {
<<<<<<< HEAD
        skill1 = Random.Range(0, skills.Length);
        skill2 = Random.Range(0, skills.Length);
        skill3 = Random.Range(0, skills.Length);
        while(skill1 == skill2) skill2 = Random.Range(0, skills.Length);
        while (skill2 == skill3 || skill3 == skill1) skill3 = Random.Range(0, skills.Length);
     /*   Debug.Log(skill1);
        Debug.Log(skill2); 
        Debug.Log(skill3);*/
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
=======
        indexChoose = new List<int>(); // làm mới ds lưu index skill được random

        foreach(var o in randomSkill())
        {
            indexChoose.Add(o); // lưu lại index random được

            GameObject tmp = Instantiate(
                skills[o].gameOJ, 
                trans_Skill[indexChoose.Count-1].transform.position, 
                Quaternion.identity, 
                trans_Skill[indexChoose.Count - 1].transform);

            tmp.transform.Find("Star").gameObject.GetComponent<Text>().text = skills[o].Star + " Star";
        }
        Time.timeScale = 0;
    }
    private HashSet<int> randomSkill()
    {
        HashSet<int> choose = new HashSet<int>();
        while(choose.Count < 3) // random đến khi chọn được 3 skill khác nhau
        {
            int ran = Random.Range(0, skills.Count);
            choose.Add(ran);
        }
        return choose;
    }
    public void onClickChooseSkill(int i)
    {
        Time.timeScale = 1; // tiếp tục game

        if (skills[indexChoose[i]].Color == "red" && skills[indexChoose[i]].Star == 0)  // nếu skill được chọn là skill red thì tang chooseRed
            numRedChoose++;
        else if (skills[indexChoose[i]].Color == "blue" && skills[indexChoose[i]].Star == 0) // ngược lại nếu là skill blue
            numBlueChoose++;

        skills[indexChoose[i]].Star++; // tăng sao cho skill được chọn

        if (numRedChoose == 4) // khi đã chọn 4 skill red, xóa các skill thừa ko chọn
        {
            // Duyệt trong các skills, nếu skills tại k là skill red và số sao vẫn còn là 0 thì bỏ
            for (int k = 0; k < skills.Count; k++)
                if (skills[k].Color == "red" && skills[k].Star == 0)
                {
                    skills.Remove(skills[k]);
                    k--;
                }
            numRedChoose++; // tăng lên 5, lần sau không lần thực hiện nữa
        }
        if (numBlueChoose == 4)
        {
            for (int k = 0; k < skills.Count; k++)
                if (skills[k].Color == "blue" && skills[k].Star == 0)
                {
                    skills.Remove(skills[k]);
                    k--;
                }
            numBlueChoose++;
        }

        // xóa 3 skill vừa hiện
        foreach (var a in trans_Skill)
            Destroy(a.gameObject.transform.GetChild(0).gameObject);
<<<<<<< Updated upstream
        }
>>>>>>> main
=======
>>>>>>> Stashed changes
        this.gameObject.SetActive(false);
    }
}
