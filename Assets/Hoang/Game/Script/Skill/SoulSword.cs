using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSword : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 50f;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
