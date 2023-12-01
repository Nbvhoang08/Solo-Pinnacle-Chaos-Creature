using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public class SpawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
<<<<<<< Updated upstream
    public GameObject Enemies;
=======
    [SerializeField] public GameObject[] Enemies;// danh sách số loại quái
    private GameObject enemies;
>>>>>>> Stashed changes
    public GameObject player;
    public float SpawnTime;
    float m_SpawnTime;
    public Countdown timeCD; // đếm ngược
    public GameObject[] EnemiesList; // danh sách số lượng quái
    public int maxEnemies; // số lượng quái tối đa
    public int CountEnemmies;
    public Countdown countDown;
    public bool addOb = true;
 /*   public Text countdownText;*/
    void Start()
    {
       CountEnemmies = 0;
       EnemiesList = new GameObject[maxEnemies];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateMaxEnemies();

        // Đảm bảo rằng EnemiesList đã được khởi tạo
      

        maxEnemiesList(maxEnemies);

        m_SpawnTime -= Time.deltaTime;
        if (m_SpawnTime <= 0)
        {
            spawnEnemies();
            m_SpawnTime = SpawnTime;
        }
    }
<<<<<<< Updated upstream
=======

    void updateMaxEnemies()
    {
        if (countDown.minutes <= 4 && countDown.seconds == 00)
        {
            if (addOb)
            {
                addOb = false;
                maxEnemies = maxEnemies*2;

                // Đảm bảo rằng EnemiesList đã được khởi tạo
                EnemiesList = new GameObject[maxEnemies];


                Debug.Log("Tăng số lượng quái: " + maxEnemies);
              
            }
        }
        else
        {
            addOb = true;
        }
    }

    void maxEnemiesList(int maxEnemies)
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("enemies");
        CountEnemmies = allEnemies.Length;

        // Lấy số lượng phần tử tối đa giữ lại
        int elementsToKeep = Mathf.Min(maxEnemies, allEnemies.Length);

        // Sao chép phần tử từ allEnemies sang EnemiesList
        for (int i = 0; i < elementsToKeep; i++)
        {
            EnemiesList[i] = allEnemies[i];
        }
    }



    GameObject GetRandomEnemies()
    {
        int randomIndex = UnityEngine.Random.Range(0, Enemies.Length);
        GameObject randomEnemy = Enemies[randomIndex];
        return randomEnemy;
    }
>>>>>>> Stashed changes
    public void spawnEnemies()
    {
        float randXPos = UnityEngine.Random.Range(player.transform.position.x - 12f, player.transform.position.x + 12f);
        float randYPos = UnityEngine.Random.Range(player.transform.position.y - 6f, player.transform.position.x + 6f);

        Vector2 spawnPos = new Vector2(randXPos, player.transform.position.y + 6f);
        Vector2 spawnPos1 = new Vector2(randXPos, player.transform.position.y - 6f);
        Vector2 spawnPos2 = new Vector2(player.transform.position.x - 12f, randYPos);
        Vector2 spawnPos3 = new Vector2(player.transform.position.x + 12f, randYPos);

        if (player)
        {
<<<<<<< Updated upstream
            Instantiate(Enemies, spawnPos, Quaternion.identity);
            Instantiate(Enemies, spawnPos1, Quaternion.identity);
            Instantiate(Enemies, spawnPos2, Quaternion.identity);
            Instantiate(Enemies, spawnPos3, Quaternion.identity);
        }
=======
            if(CountEnemmies <= maxEnemies)
            {
               if(countDown.minutes< 4) {
                    Debug.Log("Random Quái");
                    Instantiate(GetRandomEnemies(), spawnPos, Quaternion.identity);
                    Instantiate(GetRandomEnemies(), spawnPos1, Quaternion.identity);
                    Instantiate(GetRandomEnemies(), spawnPos2, Quaternion.identity);
                    Instantiate(GetRandomEnemies(), spawnPos3, Quaternion.identity);
                    // thời gian còn lại spawn ra ngẫu nhiên các loại quái
                        
                }
                else if(countDown.minutes< 5&& countDown.minutes >=4) 
                {
                    Debug.Log("quái thường");
                    enemies = Enemies[0];
                    Instantiate(enemies, spawnPos, Quaternion.identity);
                    Instantiate(enemies, spawnPos1, Quaternion.identity);
                    Instantiate(enemies, spawnPos2, Quaternion.identity);
                    Instantiate(enemies, spawnPos3, Quaternion.identity);
                    //trong 1 phut đâu tiên sẽ chỉ spawn ra quái thường
                }
           }

         }
>>>>>>> Stashed changes
    }
}
