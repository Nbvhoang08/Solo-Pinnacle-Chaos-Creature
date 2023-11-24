using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BoardGetHeroInfo : MonoBehaviour
{
    public TempInfoCharactor _tempInfoCharactor;
    // Update is called once per frame
    private Text _level;
    private Text _hp;
    private Text _damage;
    private Text _speed;
    void Start()
    {
        _level = transform.GetChild(0).GetComponent<Text>();
        _hp = transform.GetChild(1).GetComponent<Text>();
        _damage = transform.GetChild(2).GetComponent<Text>();
        _speed = transform.GetChild(3).GetComponent<Text>();
        _level.text = _tempInfoCharactor._level.ToString();
        _hp.text = _tempInfoCharactor._hp.ToString();
        _damage.text = _tempInfoCharactor._damage.ToString();
        _speed.text = _tempInfoCharactor._speed.ToString();
    }
    void Update()
    {
        _level.text = _tempInfoCharactor._level.ToString();
        _hp.text = _tempInfoCharactor._hp.ToString();
        _damage.text = _tempInfoCharactor._damage.ToString();
        _speed.text = _tempInfoCharactor._speed.ToString();
    }
}
