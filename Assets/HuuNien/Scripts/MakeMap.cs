using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cần preMap gấp đôi size của camera trở lên
public class MakeMap : MonoBehaviour
{
    [SerializeField] private GameObject preMap;
    [SerializeField] private int sizePerMap = 40;
    [SerializeField] private int sizeCamera = 10;
    private int flagCreatingMap;
    private int posInstan = 0;
    private void Start()
    {
        flagCreatingMap = sizeCamera;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mathf.Abs(transform.position.x) >= flagCreatingMap || Mathf.Abs(transform.position.y) >= flagCreatingMap)
        {
            BornMap();
            changeFlag();
        }
    }

    private void BornMap()
    {
        
        posInstan += sizePerMap;
        posInstan *= -1;
        for (int i = posInstan; i <= posInstan * -1; i+=sizePerMap)
        {
            Vector3 pos = new Vector3(i, posInstan, 0);
            Instantiate(preMap, pos, transform.rotation); 
            pos.y = - pos.y;
            Instantiate(preMap, pos, transform.rotation);
            if(i != posInstan && i != posInstan * -1)
            {
                pos.x = posInstan;
                pos.y = i;
                Instantiate(preMap, pos, transform.rotation);
                pos.x = - pos.x;
                Instantiate(preMap, pos, transform.rotation); 
            }            
        }
        posInstan *= -1;
    }
    private void changeFlag()
    {
        flagCreatingMap += sizePerMap;
    }
}
