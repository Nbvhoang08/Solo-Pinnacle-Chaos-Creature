using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using Microsoft.Unity.VisualStudio.Editor;

public class PlayerManager : MonoBehaviour
{
    // public SpriteRenderer spriteRenderer;
    public GameObject _characterSelected;
    public GameObject _showImageChactor;
    public List<GameObject> _character = new List<GameObject>();
    private int _index = 0;

    public void selectChactor(int index)
    {

        _index = index;
        UnityEngine.UI.Image imageComponent = _showImageChactor.GetComponent<UnityEngine.UI.Image>();
        imageComponent.sprite = _character[_index].GetComponent<SpriteRenderer>().sprite;
        // _showImageChactor.GetComponent<Image>().sprite = _character[_index].GetComponent<SpriteRenderer>().sprite;
        _characterSelected.GetComponent<SpriteRenderer>().sprite = _character[_index].GetComponent<SpriteRenderer>().sprite;
        _characterSelected.GetComponent<Player>()._level = _character[_index].GetComponent<Player>()._level;
        _characterSelected.GetComponent<Player>()._hp = _character[_index].GetComponent<Player>()._hp;
        _characterSelected.GetComponent<Player>()._damage = _character[_index].GetComponent<Player>()._damage;
        _characterSelected.GetComponent<Player>()._speed = _character[_index].GetComponent<Player>()._speed;
    }

    public void Play()
    {
        // PrefabUtility.SaveAsPrefabAsset(_characterSelected, "Assets/_DatDoan/_Prefab/Selected_character.prefab");
        SceneManager.LoadScene(1);
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
