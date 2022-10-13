using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    private float speed = 5;
    private Life player;
    public int damage = 5;

    public void MoveTo(Vector3 position, Vector3 dir)
    {
        transform.position = position;
        transform.up = dir;

    }
    private void Update()
    {
        transform.position = transform.position + transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collission)
    {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Life>();
        if (collission.CompareTag("Player"))
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
       
    }

}