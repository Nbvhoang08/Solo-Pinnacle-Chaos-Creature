using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    private int id;
    private string name;
    private int starSkill;
    private GameObject gameOBJ;
    private string colorSKill;
    public Skill(int id, string name, GameObject gameOBJ, int starSkill, string colorSkill)
    {
        this.id = id;
        this.name = name;
        this.starSkill = starSkill;
        this.gameOBJ = gameOBJ;
        this.colorSKill = colorSkill;
    }
    public int Star 
    {
        get { return this.starSkill; }
        set { this.starSkill = value; }
    }
    public int ID
    {
        get { return this.id; }
    }
    public string Name
    {
        get { return this.name; }
    }
    public GameObject gameOJ
    {
        get { return this.gameOBJ; }
    }
    public string Color
    {
        get { return this.colorSKill; }
    }
}
