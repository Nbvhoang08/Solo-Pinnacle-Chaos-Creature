using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSkillPlayer : MonoBehaviour
{
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
        for(int i = 0; i<skillBlue.Length + skillRed.Length; i++)
            skills.Add(new Skill(skillRed.Length + i, skillBlue[i].gameObject.name, skillBlue[i], 0, "blue"));
    }

    public void instanSkill()
    {
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
        this.gameObject.SetActive(false);
    }
}
