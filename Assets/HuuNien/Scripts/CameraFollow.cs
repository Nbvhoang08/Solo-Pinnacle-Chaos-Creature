using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    private float speed = 20f;
    private void Awake()
    {
        target = FindObjectOfType<Player>().transform;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.fixedDeltaTime);
    }
}
