using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MapEL : MonoBehaviour
{
    // Start is called before the first frame update
    private float limitDis = 10f;
    public float CurrentDis = 0;
    public Transform player;
    public float speed = 20;
    public Vector3 offset;
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetDistance();
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        if(Horizontal == -1)
        {
            offset.x = -4;
        }
        else
        {
            offset.x = 4;
        }
        if (Vertical == -1)
        {
            offset.y = -4;
        }
        else
        {
            offset.y = 4;
        }
        MoveMap();
    }
    protected void MoveMap()
    {
        if (this.CurrentDis < this.limitDis) return;
        transform.position = new Vector3(player.position.x,player.position.y,1) +offset;
        /* transform.position = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), player.position + offset, Time.fixedDeltaTime * speed);*/
    }

    protected virtual void GetDistance()
    {
        this.CurrentDis = Vector3.Distance(this.player.position, transform.position);
    }

}
