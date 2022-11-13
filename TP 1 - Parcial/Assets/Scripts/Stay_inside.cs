using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay_inside : MonoBehaviour
{

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -20.3f, 24.4f),
          Mathf.Clamp(transform.position.y, -12f, 11.3f), transform.position.z);
    }
}
