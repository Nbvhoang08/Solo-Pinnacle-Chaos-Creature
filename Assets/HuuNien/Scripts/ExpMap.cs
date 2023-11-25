using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpMap : MonoBehaviour
{
    [SerializeField] private GameObject preExp;
    private float sizeMap_x, sizeMap_y;

    private void Start()
    {
        sizeMap_x = 20;
        sizeMap_y = 20;
        makeExp();
    }

    private void makeExp()
    {
        for (int i=0;i<200;i++)
        {
            Vector3 x = new Vector3(
                Random.Range(-sizeMap_x, sizeMap_x),
                Random.Range(-sizeMap_y, sizeMap_y),
                0);
            Instantiate(preExp,transform.position + x, transform.rotation);
        }
    }
}
