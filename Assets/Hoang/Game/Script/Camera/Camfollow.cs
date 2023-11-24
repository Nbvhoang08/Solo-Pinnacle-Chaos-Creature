using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camfollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;
    public float speed = 30.0f;
    void Start()
    {
        target = Object.FindAnyObjectByType<Player>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y,-10), target.position + offset, Time.deltaTime * speed);
    }
}
