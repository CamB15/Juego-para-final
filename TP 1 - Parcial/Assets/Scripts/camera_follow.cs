using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public GameObject player;
    [Range(0, 0.5f)]
    public float smoothtime = 0.05f;

    void LateUpdate()
    {
        Vector3 empty = Vector3.zero;
        Vector3 newposition= Vector3.SmoothDamp(transform.position, player.transform.position, ref empty, smoothtime);
        newposition.z = -10;

        transform.position = newposition;

        

    }

}
