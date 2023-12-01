using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOT : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject soulsword;
    public Transform player;
    public float maxObject;
    // sử dụng spawnObjectOT để spawn object lúc vào game đối với các object cố định ko bị destroy
    void Start()
    {
       for (int i = 0; i <= maxObject; i++)
        {
            Instantiate(soulsword, player.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
