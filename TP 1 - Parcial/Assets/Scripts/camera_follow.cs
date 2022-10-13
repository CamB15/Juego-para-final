using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{

    public GameObject target;
    private float targetX;
    private float targetY;

    private float posX;
    private float posY;

    public float rightMax;
    public float leftMax;
    public float heightMax;
    public float heightMin;

    public float speed;



    void Move()
    {
        if (target)
        {
            targetX = target.transform.position.x;
            targetY = target.transform.position.y;
            if(targetX > leftMax && targetX < rightMax)
            {
                posX = targetX;
            }
            if ( targetY<heightMax && targetY > heightMin)
            {
                posY = targetY;
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), speed * Time.deltaTime);

        }
    }
    void Update()
    {
        Move();
    }

}
